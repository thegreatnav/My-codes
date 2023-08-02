import java.util.*;
public class Booking
{
    static String rec[][]=new String[41][10];
    public static void main(String args[])
    {
        Booking obj= new Booking();
        Scanner sc = new Scanner(System.in);
        int i,j;
        for(i=0;i<40;i++)//input blocks
        {   
            if(i>=0&&i<10)
            rec[i][0]="1";
            else if(i>=10&&i<=19)
            rec[i][0]="2";
            else if(i>=20&&i<=29)
            rec[i][0]="3";
            else
            rec[i][0]="4";
        }
        int count=100;
        for(i=0;i<=39;i++)//input rooms
        {
            if(i==0||i==10||i==20||i==30)
                count=100;
            rec[i][1]=Integer.toString(count);
            count++;
        }
        j=1;
        for(i=0;i<=39;i++)//capacity
        {
            if(j==1||j==2)
            {
                rec[i][2]="1";
                j++;
            }
            else if(j>=3&&j<=5)
            {
                rec[i][2]="2";
                if(j==5)
                    j=0;
                j++;
            }
        }
        j=1;
        for(i=0;i<=39;i++)//price
        {
            if(j>=1&&j<=2)
            {
                rec[i][3]="1.00";
                j++;
            }
            else if(j>=3&&j<=5)
            {
                rec[i][3]="75k";
                j++;
            }
            else if(j>=6&&j<=7)
            {
                rec[i][3]="1.50";
                j++;
            }
            else if(j>=8&&j<=10)
            {
                rec[i][3]="1.25";
                if(j==10)
                    j=0;
                j++;
            }
        }
        j=1;
        for(i=0;i<=39;i++)//AC
        {
            if(j<=5)
                rec[i][8]="NonAC";
            else if(j>5&&j<10)
                rec[i][8]="AC";
            else
            {
                rec[i][8]="AC";
                j=0;
            }
            j++;
        }
        for(i=0;i<=39;i++)//status
        {
            rec[i][9]="0";
        }
        System.out.println("\t\t\t\tWelcome to Hostel Management System");
        int sw=5;
        do
        {
            System.out.println("\nEnter choice:\t1.Reserve a room\t2.Cancel a room booking \t3.View room status\t4.View record\t5.Exit");
            sw=sc.nextInt();
            switch(sw)
            {
                case 1:
                System.out.println("Enter name of student:");
                String name=sc.next();
                System.out.println("Enter gender(M or F)");
                char gender=sc.next().charAt(0);
                System.out.println("Enter semester");
                int sem=sc.nextInt();
                System.out.println("Enter CGPA");
                double cgpa=sc.nextDouble();
                obj.check(name,gender,cgpa,sem);
                break;
                case 2:
                System.out.println("Enter block");
                String b=sc.next();
                System.out.println("Enter room number");
                String r=sc.next();
                obj.cancel(b,r);
                break;
                case 3:
                System.out.println("Enter block number");
                int bl=sc.nextInt();
                System.out.println("Enter room number");
                int ro=sc.nextInt();
                int flag1=0;
                for(i=0;i<=39;i++)
                {
                    if((Integer.parseInt(rec[i][0])==bl)&&(Integer.parseInt(rec[i][1])==ro))
                    {
                        flag1=1;
                        System.out.println("Block  Room Capacity   Price   Name   Gender   CGPA   Semester   AC/NonAC Status");
                        for(j=0;j<10;j++)
                        {
                            System.out.print(rec[i][j]+"\t");
                        }
                        System.out.println("");
                    }
                }
                if(flag1==0)
                {
                    System.out.println("Invalid block or room");
                }
                break;
                case 4:
                obj.display();
                break;
                case 5:
                break;
                default:
                System.out.println("Try again");
            }    
        }while(sw!=5);
        System.out.println("\n\t\t\t\tThank you for using Hostel Management System.");
    }
    void check(String name,char gender,double cgpa,int sem)
    {
        if(gender=='M'||gender=='m')
        {
            if(cgpa<5)
            allot(1,name,gender,cgpa,sem);
            else 
            allot(2,name,gender,cgpa,sem);
        }
        else if(gender=='F'||gender=='f')
        {
            if(cgpa<5)
            allot(3,name,gender,cgpa,sem);
            else
            allot(4,name,gender,cgpa,sem);
        }
        else
        System.out.println("Invalid input for gender");
    }
    void allot(int a,String name,char gender,double cgpa,int sem)
    {
        if(a==1)
        {
            int A[]={1};
            choice(A,name,gender,cgpa,sem);
        }
        else if(a==2)
        {
            int A[]={1,2};
            choice(A,name,gender,cgpa,sem);
        }
        else if(a==3)
        {
            int A[]={3};
            choice(A,name,gender,cgpa,sem);
        }
        else
        {
            int A[]={3,4};
            choice(A,name,gender,cgpa,sem);
        }
    }
    void choice(int A[],String name,char gender,double cgpa,int sem)
    {
            Scanner sc = new Scanner(System.in);
            int flag=0,i=0;
            System.out.print("Available hostels: ");
            for(i=0;i<A.length;i++)
                System.out.print(A[i]+" ");
            System.out.println("");
            System.out.println("Enter hostel choice");
            int cho=sc.nextInt();
            for(i=0;i<A.length;i++)
            {
                if(cho==A[i])
                {
                    flag=1;
                    break;
                }
            }
            if(flag==0)
                System.out.println("Invalid choice. Try again");
            else
            {
                switch(cho)
                {
                    case 1:
                    block1(name,gender,cgpa,sem);
                    break;
                    case 2:
                    block2(name,gender,cgpa,sem);
                    break;
                    case 3:
                    block3(name,gender,cgpa,sem);
                    break;
                    case 4:
                    block4(name,gender,cgpa,sem);
                    break;
                    default:
                    System.out.println("Error");
                }
            }
           
    }
    void block1(String name,char gender,double cgpa,int sem)
    {
        Scanner sc=new Scanner(System.in);
        int m;
        System.out.println("Enter type of room\t1.AC\t2.Non-AC");
        int n=sc.nextInt();
        if(n==1)
        {
            System.out.println("Available rooms:");
            for(int i=105;i<110;i++)
                System.out.print(i+" ");
            System.out.println("");
            System.out.println("Enter choice:");
            m=sc.nextInt();
            int flag=0;
            for(int i=105;i<110;i++)
            {    
                if(m==i)
                flag=1;
            }
            if(flag==0)
            System.out.println("Invalid input");
            else
            {
                record(1,m,name,gender,cgpa,sem);
            }
        }
        else if(n==2)
        {
            System.out.println("Available rooms:");
            for(int i=100;i<105;i++)
                System.out.print(i+" ");
            System.out.println("");
            System.out.println("Enter choice:");
            m=sc.nextInt();
            int flag=0;
            for(int i=100;i<105;i++)
            {    
                if(m==i)
                flag=1;
            }
            if(flag==0)
            System.out.println("Invalid input");
            else
            {
            record(1,m,name,gender,cgpa,sem);
            }
        }
        else
        System.out.println("Invalid input");
        
    }
    void block2(String name,char gender,double cgpa,int sem)
    {
        Scanner sc=new Scanner(System.in);
        int m;
        System.out.println("Enter type of room\t1.AC\t2.Non-AC");
        int n=sc.nextInt();
        if(n==1)
        {

        
            System.out.println("Available rooms:");
            for(int i=105;i<110;i++)
                System.out.print(i+" ");
            System.out.println("");
            System.out.println("Enter choice:");
            m=sc.nextInt();
            int flag=0;
            for(int i=105;i<110;i++)
            {    
                if(m==i)
                flag=1;
            }
            if(flag==0)
            System.out.println("Invalid input");
            else
            {
                record(2,m,name,gender,cgpa,sem);
            }
        }
        else if(n==2)
        {
            System.out.println("Available rooms:");
            for(int i=100;i<105;i++)
                System.out.print(i+" ");
            System.out.println("");
            System.out.println("Enter choice:");
            m=sc.nextInt();
            int flag=0;
            for(int i=100;i<105;i++)
            {    
                if(m==i)
                flag=1;
            }
            if(flag==0)
            System.out.println("Invalid input");
            else
            {
            record(2,m,name,gender,cgpa,sem);
            }
        }
        else
        System.out.println("Invalid input");
        
    }
    void block3(String name,char gender,double cgpa,int sem)
    {
        Scanner sc=new Scanner(System.in);
        int m;
        System.out.println("Enter type of room\t1.AC\t2.Non-AC");
        int n=sc.nextInt();
        if(n==1)
        {
            System.out.println("Available rooms:");
            for(int i=105;i<110;i++)
                System.out.print(i+" ");
            System.out.println("");
            System.out.println("Enter choice:");
            m=sc.nextInt();
            int flag=0;
            for(int i=105;i<=110;i++)
            {    
                if(m==i)
                flag=1;
            }
            if(flag==0)
            System.out.println("Invalid input");
            else
            {
                record(3,m,name,gender,cgpa,sem);
            }
        }
        else if(n==2)
        {
            System.out.println("Available rooms:");
            for(int i=100;i<105;i++)
                System.out.print(i+" ");
            System.out.println("");
            System.out.println("Enter choice:");
            m=sc.nextInt();
            int flag=0;
            for(int i=100;i<105;i++)
            {    
                if(m==i)
                flag=1;
            }
            if(flag==0)
            System.out.println("Invalid input");
            else
            {
            record(3,m,name,gender,cgpa,sem);
            }
        }
        else
        System.out.println("Invalid input");
        
    }
    void block4(String name,char gender,double cgpa,int sem)
    {
        Scanner sc=new Scanner(System.in);
        int m;
        System.out.println("Enter type of room\t1.AC\t2.Non-AC");
        int n=sc.nextInt();
        if(n==1)
        {
            System.out.println("Available rooms:");
            for(int i=105;i<110;i++)
                System.out.print(i+" ");
            System.out.println("");
            System.out.println("Enter choice:");
            m=sc.nextInt();
            int flag=0;
            for(int i=105;i<110;i++)
            {    
                if(m==i)
                flag=1;
            }
            if(flag==0)
            System.out.println("Invalid input");
            else
            {
                record(4,m,name,gender,cgpa,sem);
            }
        }
        else if(n==2)
        {
            System.out.println("Available rooms:");
            for(int i=100;i<105;i++)
                System.out.print(i+" ");
            System.out.println("");
            System.out.println("Enter choice:");
            m=sc.nextInt();
            int flag=0;
            for(int i=100;i<105;i++)
            {    
                if(m==i)
                flag=1;
            }
            if(flag==0)
            System.out.println("Invalid input");
            else
            {
            record(4,m,name,gender,cgpa,sem);
            }
        }
        else
        System.out.println("Invalid input");
        
    }
    void cancel(String block,String room)
    {
        Scanner sc=new Scanner(System.in);
        int i,flag2=0;
        for(i=1;i<=40;i++)
        {
            if((block.equals(rec[i][0])) && (room.equals(rec[i][1])))
            {
                flag2=1;
                if(rec[i][9].equals("1"))
                {
                    rec[i][4]=null;
                    rec[i][5]=null;
                    rec[i][6]=null;
                    rec[i][7]=null;
                    rec[i][9]="0";
                    System.out.println("Cancellation of block "+rec[i][0]+" room "+rec[i][1]+" is done.");
                }
                else
                System.out.println("Room is unallotted");
            }
        }
        if(flag2==0)
            System.out.println("Invalid block or room");
    }
    void record(int block,int room,String name,char gender,double cgpa,int sem)
    {
        Scanner sc=new Scanner(System.in);
        for(int i=0;i<=39;i++)
        {
                if((rec[i][1].equals(Integer.toString(room)))&&(rec[i][0].equals(Integer.toString(block))))
                {
                    if(rec[i][9].equals(rec[i][2]))
                    {
                        System.out.println("Sorry room already booked.");
                        break;
                    }
                    else
                    {
                        System.out.println("Block  Room Capacity   Price   AC/NonAC Status");
                        for(int j=0;j<4;j++)
                        System.out.print(rec[i][j]+"\t");
                        for(int j=8;j<10;j++)
                        System.out.print(rec[i][j]+"\t");
                        System.out.println("");
                        System.out.println("Confirm booking?  1.Yes   2.No");
                        int cont=sc.nextInt();
                        if(cont==1)
                        {
                            if(rec[i][4]!=null)
                                rec[i][4]=rec[i][4]+","+name;
                            else
                                rec[i][4]=name;
                            if(rec[i][5]!=null)
                                rec[i][5]=rec[i][5]+","+(Character.toString(gender));
                            else
                                rec[i][5]=(Character.toString(gender));
                            if(rec[i][6]!=null)
                                rec[i][6]=rec[i][6]+","+(Double.toString(cgpa));
                            else
                                rec[i][6]=Double.toString(cgpa);
                            if(rec[i][7]!=null)
                                rec[i][7]=rec[i][7]+","+(Integer.toString(sem));
                            else
                                rec[i][7]=Integer.toString(sem);
                            rec[i][9]=Integer.toString(Integer.parseInt(rec[i][9])+1);
                            System.out.println("You have been allotted Block:"+rec[i][0]+" Room:"+rec[i][1]);
                        }
                        else
                        break;
                    }
                }
        }
    }
    void display()
    {
        int i,j;
        System.out.println("Block  Room Capacity   Price   Name   Gender   CGPA   Semester   AC/NonAC Status");
        for(i=0;i<=39;i++)//display
        {
            for(j=0;j<10;j++)
            {
                System.out.print(rec[i][j]+"\t");
            }
            System.out.println("");
        }
    }
}