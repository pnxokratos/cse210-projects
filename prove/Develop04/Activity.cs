using System;
using static System.Console;

class Activity
{
    //Variables.
    private string _welcomeText;
    private string _activityDiscription;
    private int _sessionTime;
    private string _finishMessage;

    public string GetWelcomText()
    {
        return _welcomeText;
    }
    public void SetWelcomeText(string Text)
    {
        _welcomeText = Text;
    }

    public string GetActivityDiscription()
    {
        return _activityDiscription;
    }
    public void SetActivityDiscription(string Discription)
    {
        _activityDiscription = Discription;
    }

    public void SetSessionTime(string time)
    {
        int intTime = int.Parse(time);
        _sessionTime = intTime;
    }
    public int GetSessionTime()
    {
        return _sessionTime;
    }

    public void SetFinishMessage(string Message)
    {
        _finishMessage = Message;
    }
    public string GetFinishMessage()
    {
        return _finishMessage;
    }



    public void TimerCountdown(int time)
    {
        int seconds = time/1000;
        for (int i = seconds; i > 0; i--)
        {
            Write(i);
            Thread.Sleep(1000);
            Backspace();
        }
    }
    public void Backspace()
    {
        Write("\b \b");
    }
    public void Animation(int time)
    {
        double seconds = time/1000;
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");

        while (seconds > 0)
        {
            string s = animationStrings[0];
            Thread.Sleep(200);
            seconds -=.2;
            Write("\b \b");
            Write(s);

            s = animationStrings[1];
            Thread.Sleep(200);
            seconds -=.2;
            Write("\b \b");
            Write(s);

            s = animationStrings[2];
            Thread.Sleep(200);
            seconds -=.2;
            Write("\b \b");
            Write(s);
            
            s = animationStrings[3];
            Thread.Sleep(200);
            seconds -=.2;
            Write("\b \b");
            Write(s);
        }
        
    }
    public void startTimer()
    {
        while(_sessionTime != 0)
        {
            TimerCountdown(1000);
            _sessionTime -= 1;
        }
    }
}