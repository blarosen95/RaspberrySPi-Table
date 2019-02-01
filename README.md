# RaspberrySPi-Table
  After visiting Manhattan's SpyScape exhibit, I took the E train uptown and started wondering what I should do with the NFC enabled identification bracelet I was allowed to keep. A (Ikea if it really matters to you) coffee table hack which will involve fitting a Windows 10 IoT device (and a screen flush with the top of the table) was the best idea I came up with. This project will obviously utilize NFC and Win10 IoT. However, I also plan to implement some AWS features such as Amazon Polly to really bring this hack to life.

  Now, a fair amount of this project is actually finished and works. However, I decided (fairly last minute I know) to not use UWP, and use .NET Core instead so that I can just run Linux on the Pi instead of Windows 10 IOT. There will still be a UWP app for the Windows PC that will be controlled by the Pi for various HTPC purposes. AWS Polly went right out the window when I compared its quality to Azure TTS (not to mention the fact that Azure TTS has a Free Forever Pricing point that can easily be maintained with a small userbase). So a lot of it will be rewritten before I ever commit (if ever) it publicly.
