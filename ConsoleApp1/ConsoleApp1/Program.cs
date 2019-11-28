using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
delegate void Notify(string message); //Notify 델리게이트 선언



class Notifier //Notify 델리게이트의 인스턴스 EventOccured를 가지는 클래스
{
    public Notify EventOccured;
}



class EventListener
{
    private string name;
    public EventListener(string name)
    {
        this.name = name;
    }

    public void SomethingHappened(string message)
    {
        Console.WriteLine("{0}.SomethingHappened : {1}", name, message);
    }
}

public class MainApp
{
    public static void Main(string[] args)
    {
        Notifier notifier = new Notifier();
        EventListener listener1 = new EventListener("Listener1");
        EventListener listener2 = new EventListener("Listener2");
        EventListener listener3 = new EventListener("Listener3");



        // += 연산자를 이용해 체인 만들기
        notifier.EventOccured += listener1.SomethingHappened;
        notifier.EventOccured += listener2.SomethingHappened;
        notifier.EventOccured += listener3.SomethingHappened;

        notifier.EventOccured("You've got mail.");
        Console.WriteLine();



        // -= 연산자를 이용한 체인 끊기
        notifier.EventOccured -= listener2.SomethingHappened;
        notifier.EventOccured("Download complete");

        Console.WriteLine();



        // +, = 연산자를 이용한 체인 만들기
        notifier.EventOccured = new Notify(listener2.SomethingHappened)

                                         + new Notify(listener3.SomethingHappened);
        notifier.EventOccured("Nuclear launch detected.");

        Notify notify1 = new Notify(listener1.SomethingHappened);
        Notify notify2 = new Notify(listener2.SomethingHappened);



        // Delegate.Combine()메소드를 이용한 체인 만들기
        notifier.EventOccured = (Notify)Delegate.Combine(notify1, notify2);
        notifier.EventOccured("Fire!!");

        Console.WriteLine();



        // Delegate.Remove()메소드를 이용한 체인 끊기
        notifier.EventOccured = (Notify)Delegate.Remove(notifier.EventOccured, notify2);
        notifier.EventOccured("RPG!");
    }
}
