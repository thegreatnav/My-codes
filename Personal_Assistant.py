import pyttsx3
import speech_recognition
import datetime
import time
import wikipedia
import os
import ecapture
import webbrowser
import wolframalpha
import pyjokes
from pydub import AudioSegment
from pydub.playback import play
import json
import requests
from geopy.geocoders import Nominatim
from geopy.point import Point
import spotipy
import sys
from AppOpener import open,close,mklist,give_appnames
from twilio.rest import Client

r = speech_recognition.Recognizer()
mytext=""
mklist(name="app_data.json")
appnames=give_appnames()

def speaktext(text):
    engine1=pyttsx3.init('sapi5')
    engine1.setProperty('rate',150)
    voices = engine1.getProperty('voices')
    selected_voice = voices[0].id
    engine1.setProperty('voice', selected_voice)
    one_sec_segment = AudioSegment.silent(duration=1000)
    play(one_sec_segment)
    engine1.say(text)
    engine1.runAndWait()
    engine1.stop()

def voicecmd1():
    global mytext
    with speech_recognition.Microphone() as source1:
        r.pause_threshold = 1
        aud=r.listen(source1,0,5)
        try:
            r.adjust_for_ambient_noise(source1,0.5)
            mytext=r.recognize_google(aud,language="en-in")
            print(mytext)
            speaktext(mytext)
        except Exception as e:
            speaktext("Pardon me, please say that again")
            voicecmd1()

"""def voicecmd2():
    with speech_recognition.Microphone() as source1:
        aud1=r.listen(source1)
        try:
            response=r.recognize_google(aud1)
            if "no" in response:
                speaktext("You said no")
            elif "yes" in response:
                speaktext("You said yes")
            else:
                speaktext("Pardon me, please say that again")
                voicecmd2()
        except Exception as e:
            speaktext("Pardon me, please say that again")
            voicecmd2()"""

def wishMe(name1):
    hour1=datetime.datetime.now().hour
    if hour1>=0 and hour1<12:
        speaktext("Good Morning"+name1)
        print("Good Morning "+name1)
    elif hour1>=12 and hour1<18:
        speaktext("Good Afternoon"+name1)
        print("Good Afternoon "+name1)
    else:
        speaktext("Good Evening"+name1)
        print("Good Evening "+name1)

def func3():
    global mytext

    if "Wikipedia" in mytext and "search" in mytext:
        speaktext('Searching Wikipedia...')
        mytext =mytext.replace("Wikipedia", "")
        results = wikipedia.summary(mytext, sentences=3)
        speaktext("According to Wikipedia")
        print(results)
        speaktext(results)
        
    elif 'search' in mytext:
        if 'YouTube' in mytext:
            mytext=mytext.replace("search about","")
            mytext=mytext.replace("in YouTube","")
            mytext=mytext.replace("search for","")
            mytext=mytext.replace("on YouTube","")
            mytext=mytext.replace("look up","")
            mytext=mytext.replace("search","")
            searcharr=mytext.split(" ")
            print(searcharr)
            strnew=""
            i=0
            for i in range(len(searcharr)):
                if(len(searcharr[i])!=0):
                    strnew=strnew+searcharr[i]
                    strnew=strnew+"+"
            strnew=strnew[:len(strnew)-1]
            search_string="https://www.youtube.com/results?search_query="+strnew
            webbrowser.open_new_tab(search_string)
            speaktext("The Youtube search has been opened")
            time.sleep(5)

        else:
            mytext=mytext.replace("search about","")
            mytext=mytext.replace("in Google","")
            mytext=mytext.replace("search for","")
            mytext=mytext.replace("on Google","")
            mytext=mytext.replace("look up","")
            searcharr=mytext.split(" ")
            print(searcharr)
            strnew=""
            i=0
            for i in range(len(searcharr)-1):
                strnew=strnew+searcharr[i]
                strnew=strnew+"+"
            strnew=strnew+searcharr[i+1]
            search_string="https://www.google.com/search?q="+strnew
            webbrowser.open_new_tab(search_string)
            speaktext("The Google search has been opened")
            time.sleep(5)

    elif 'send SMS' in mytext:
            print("Speak out recipient's phone number along with country code")
            speaktext("Speak out recipient's phone number along with country code")
            with speech_recognition.Microphone() as source1:
                aud=r.listen(source1)
                try:
                    r.adjust_for_ambient_noise(source1,0.5)
                    rec_num=r.recognize_google(aud,language="en-in")
                    print(rec_num)
                    speaktext(rec_num)
                except Exception as e:
                    speaktext("Pardon me, I could not process the request")

            print("Dictate the contents of the message")        
            speaktext("Dictate the contents of the message")
            with speech_recognition.Microphone() as source1:
                aud=r.listen(source1,0,10)
                try:
                    r.adjust_for_ambient_noise(source1,0.5)
                    msg_body=r.recognize_google(aud,language="en-in")
                    print(msg_body)
                    speaktext(msg_body)
                except Exception as e:
                    speaktext("Pardon me, I could not process the request")
            
            flag=0
            while flag!=1:
                print("Confirm sending message. (Yes/No)")
                speaktext("Confirm sending message. Yes or no")
                with speech_recognition.Microphone() as source1:
                    aud=r.listen(source1,0,10)
                    try:
                        r.adjust_for_ambient_noise(source1,0.5)
                        msg_confirm=r.recognize_google(aud,language="en-in")
                        print(msg_confirm)
                        speaktext(msg_confirm)
                    except Exception:
                        speaktext("Pardon me, I could not process the request")
                if 'no' in msg_confirm or 'not' in msg_confirm:
                    flag=0
                    print("Message cancelled")
                    speaktext("Message cancelled")
                elif 'yes' in msg_confirm or 'confirm' in msg_confirm:
                    flag=0
                    account_sid = 'AC76433759e562949c722c9dd0bf5de4d7'
                    auth_token = '9c84031b707d12eb3b9c808aaf8bbccf'
                    client = Client(account_sid, auth_token)

                    client.messages.create(
                    from_='+19792562479',
                    to=rec_num,
                    body=msg_body
                    )

                    print("Message sent successfully")
                    speaktext("Message sent successfully")
                else:
                    flag=1
                    speaktext("Could you say yes or no please?")

    elif 'open Google' in mytext:
        webbrowser.open_new_tab("https://www.google.com")
        speaktext("Google chrome is open now")
        time.sleep(5)

    elif 'open Gmail' in mytext:
        webbrowser.open_new_tab("gmail.com")
        speaktext("Google Mail open now")
        time.sleep(5)
    
    elif 'time' in mytext:
        speaktext("The time is ")
        strTime=datetime.datetime.now().strftime("%H:%M:%S")
        speaktext(strTime)
    
    elif 'news' in mytext or 'headlines' in mytext:
        webbrowser.open_new_tab("https://timesofindia.indiatimes.com/home/headlines")
        speaktext('Here are some headlines from the Times of India\nHappy reading\n')
        time.sleep(5)

    elif 'camera' in mytext or 'take a photo' in mytext:
        ecapture.capture(0,"robo camera","img.jpg")
    
    elif 'video' in mytext or 'capture a footage' in mytext:
        ecapture.vidCapture(0,"robo camera","vid1.avi",'x')
    
    elif 'joke' in mytext:
        x=pyjokes.get_joke()
        speaktext(x)
        print(x)
    
    elif 'latitude' in mytext or 'longitude' in mytext or 'coordinates' in mytext:
        try:
            place=mytext.split("of")
            place1=place[1]
            print(place1)
            loc = Nominatim(user_agent="Personal_Assistant")
            getLoc = loc.geocode(place1)
            print("Latitude = ", getLoc.latitude, "\n")
            print("Longitude = ", getLoc.longitude)
            ans=[]
            ans.append(getLoc.latitude)
            ans.append(getLoc.longitude)
            locname = loc.reverse(ans)
            print(locname.address)
        except Exception as e:
            print("Sorry, unable to process request")
            speaktext("Sorry, unable to process request")

    elif 'spotify' in mytext or 'play music' in mytext:
        oauth_object = spotipy.SpotifyOAuth('67b47b8297114b6f912bc46a512f732a','37d9b328a0244cd4945c1f2519c160d6','https://localhost:8888/callback')
        token_dict = oauth_object.get_access_token()
        token = token_dict['access_token']
        spotifyObject = spotipy.Spotify(auth=token)     
        print("Which song do you want to play?")
        speaktext("Which song do you want to play?")
        with speech_recognition.Microphone() as source1:
            aud=r.listen(source1)
            try:
                r.adjust_for_ambient_noise(source1,0.5)
                search_song=r.recognize_google(aud,language="en-in")
                print(search_song)
                speaktext(search_song)
            except Exception as e:
                speaktext("Pardon me, I could not process the request")
        results = spotifyObject.search(search_song, 1, 0, "track")
        songs_dict = results['tracks']
        song_items = songs_dict['items']
        song = song_items[0]['external_urls']['spotify']
        webbrowser.open(song)
        print('Song has opened in your browser.')

    elif 'open' in mytext:
        print("this")
        openstring=mytext.replace("open","")
        openstring=openstring.strip()
        print(openstring)
        appnames=give_appnames()
        print(appnames)
        if openstring in appnames:
            speaktext("Opening "+openstring)
            open(openstring)
        else:
            speaktext("App not found")
            print("App not found")
        time.sleep(5)

    elif 'exit' in mytext or 'bye' in mytext or 'end' in mytext or 'no thank you' in mytext or 'shutdown' in mytext:
        print("Ending program.")
        speaktext("Ending program. Have a good day")
        exit()

    else:
        app_id = '7KQPT6-7733P3G8V7'
        client = wolframalpha.Client(app_id)
        try:
            res = client.query(mytext)
            answer = next(res.results).text
            print(answer)
            speaktext(answer)
        except Exception as e:
            print("Could you be more specific?")
            speaktext("Could be more specific?")
            voicecmd1()
            func3()

print("Welcome !!!")
print("Please enter your name.")
name1=input()
wishMe(name1)
i=0
while(True):
    if i==0:
        speaktext("How may I help you today?")
    else:
        speaktext("Is there anything else I can help you with?")
    i=i+1
    voicecmd1()
    func3()