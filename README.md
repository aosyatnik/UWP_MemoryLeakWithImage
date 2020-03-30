# UWP_MemoryLeakWithImage
Before you try to understand memory leak I want to try to explain how I got to this memory leak. I wanted to have some control, that will switch images. Something like an emulation of gif.
I wanted some image to be shown for some time, after that, another image should be shown. Also, I wanted to implement some transition animations, but in this example, this doesn't really matter. 

So, I created `BackgroundImage` and `ForegroundImage` and added `DispatcherTimer _imageTimer`. When both background and foreground were ready, timer starts and the image is shown for 1 second. This was looking like this:

![without_previous_file](Images/without_previous_file.gif?raw=true "Title")

I didn't like, that there is a white blink when an image is loading. So I decided to add a so-called "previous" file. This is an image, that was before. And it kind of worked (although foreground image was still blinking background image was shown fine and I was happy even with this):

![with_previous_file](Images/with_previous_file.gif?raw=true "Title")

### Now memory leak!
If you open `MainViewModel.cs` and change this code:
`public OverlayBackground OverlayBackground { get; set; } = OverlayBackground.fx;`
into this code:
`public OverlayBackground OverlayBackground { get; set; } = OverlayBackground.black;`

This will change background into solid color. Should work like this:
![with_black_background](Images/with_black_background.gif?raw=true "Title")

And now check Process Memory, when background image is visible(fx) it's ok:
![normal_memory](Images/normal_memory.JPG?raw=true "Title")

But as soon as background image is hidden (black background) it's raising continuously:
![normal_memory](Images/memory_leak.JPG?raw=true "Title")
