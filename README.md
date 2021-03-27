# GifMemoryBlow
this is example of gif hight resources consumption in UWP app. 

## Steps to reproduce
1. Run application
2. Open Task manager, observe very hight CPU utilisation
3. Minimize application (do not stop playback, but you can turn volume off)
4. Wait for about 3 minutes (depends of your PC hardvare)
5. Restore app
6. Observe how all you RAM is gone, 100% disk utilisation. PC is unresponsive

## Workaround for memory consumption in background

uncomment behavior. It will stop gifs when app is minimized

``` xaml
<Image Width="150" Height="150" Source="ms-appx:///cortana.gif">
    <!--Fix for memory consuption in background-->
    <!--<interactivity:Interaction.Behaviors>
        <local:PauseGifInBackgroundBehavior/>
    </interactivity:Interaction.Behaviors>-->
</Image>
```
