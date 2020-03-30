# UWP_MemoryLeakWithImage
Before you try to understand memory leak I want to try to explain how I got to this memory leak. So I wanted to have some control, that will switch images. Something like an emulation of gif.
I wanted some image to be shown for some time, after that, another image should be shown. Also, I wanted to implement some transition animations, but in this example, this doesn't really matter. 

So, I created `BackgroundImage` and `ForegroundImage` and added `DispatcherTimer _imageTimer`. When both background and foreground were both ready timer starts and the image is shown for 1 second. This was looking like this:

![without_previous_file](Images/without_previous_file.gif?raw=true "Title")
