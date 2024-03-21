# Viewer2Explorer: 360-Video-Navigation-Map-Interface

[<img src="" width="100%">](https://youtu.be/CcEvbhE71a0)

The pandemic has contributed to the increased digital content development for remote experiences. Notably, museums have begun creating virtual exhibitions using 360-videos, providing a sense of presence and high level of immersion. However, 360-video content often uses a linear timeline interface that requires viewers to follow the path decided by the video creators. This format limits viewers’ ability to actively engage with and explore the virtual space independently. Therefore, we designed a map-based video interface, Viewer2Explorer(V2E), that enables the user to perceive and explore virtual spaces autonomously. We then conducted a study to compare the overall experience between the existing linear timeline and map interfaces. V2E enhanced users' spatial controllability and enabled active exploration in virtual museum exhibition spaces. Additionally, based on our map interface, we discuss a new type of immersion and guided autonomy that can be experienced through a 360-video interface and provide design insights for future content.

![main](https://github.com/jinwook31/360-Video-Navigation-Map/blob/main/Figures/main.PNG)

---

### Installation
Download and Unzip the project file. Open with the appropriate Unity version.

* Due to the project size (360 video), the full project and code can be downloaded through the Dropbox link (https://www.dropbox.com/s/cl6aynr8htkz1cq/360%20Video%20Navigation%20Map.egg?dl=0) or contact the author.
* You could experience the Viewer2Explorer interface demo with the exe file easily.


#### Environment
Unity Editor (Version: 2019.4.2f1)

---

### Interface structure
![interfaceFunc](https://github.com/jinwook31/360-Video-Navigation-Map/blob/main/Figures/Functions.PNG)

#### Interaction
Similar to moving to a specific time point by clicking on the timeline in the conventional video interface, viewers can move to a specific location by clicking on a particular spot on the path in the map interface. Since the path was created by bending the timeline, manipulating the video through the map is the same as manipulating the video‘s timeline. However, we hypothesized that this could induce users to feel that they are navigating spatially rather than temporally through the map.

In addition, our interface attempts to induce viewers to explore space actively by continuously giving them options, even for passive viewing, without moving indicators. For example, whenever the video of \textit{Path n} ends and faces a crossroads, the video is stopped, and the viewer can choose the direction they want to proceed by clicking the arrow in the map interface. Then the video proceeds to the path that the viewer chose. Viewers can manipulate gaze direction through mouse manipulation while playing the video. Choosing a route at a crossroads could be difficult if the gaze direction was not maintained in the same direction as the videographer when stopping the video. To prevent this, we rotated the view direction slowly to face the same field of view as the videographer when the video was paused.

#### Video control
In the map interface, users can manipulate the movement of the videographer through the four functions that have been used in the timeline interface. The video navigation function consists of play/pause, faster, slower, and skip buttons. Viewers could utilize these four functions using the keyboard arrow keys and the space key, similar to the timeline interface. In addition, the fast, slow, and skip functions were redesigned in the prototyping process to reduce the awkwardness when video control functions originally designed for temporal interaction were replaced with movement control for spatial navigation.

The detailed actions for each function are as follows. Firstly, the speed control (i.e., fast and slower functions) was modified only to accelerate or decelerate while the key was pressed. The timeline interface's speed control function behaves like a hardware toggle button; when pressed once, the state changes and the video speed remains constant until the key is pressed again. Toggle buttons are suitable for situations where discrete state changes are infrequently required. However, this was replaced with a momentary switch interaction in the map interface to provide continuous control, enabling viewers to accelerate and decelerate more comfortably and naturally. This choice was made considering viewers' frequent use of speed control for active exploration within the virtual space. 

In the map interface, the skip function was also transformed into an interaction that allows viewers to skim through space five seconds later rather than jumping to a time five seconds later. This function was designed to provide a smooth spatial transition, helping viewers intuitively understand how they arrived at a location five seconds in the future. Consequently, even if the user transitions to the space after five seconds, viewers would perceive it as a rapid movement within the same space rather than a separate scene.


### Project structure
Based on the design considerations, we implemented these interfaces with Unity Engine (2019.4.2f1). The 360-degree video was recorded using Ricoh Theta V, and it was played with the 360 video player asset (Interactive360). This asset provides basic video play, pause, and skip functions and information on the current video status, such as the current frame and time. We used these functions and information to map the video status on the progress bar and button input interactions. Also, the map interface was implemented based on the progress bar mechanism, but the bar was split when the route was in a rotating (intersecting, bending) point, and it was placed on the map image. The corresponding video time point was assigned to each progress bar to show the appropriate video when viewers pressed the bar (position control). The viewer indicator was synced with the video time and camera rotation. For coin interaction, we used the collision function to remove coins when viewers have gone through the path.

* Videoprogressbar.cs
    * linearBars assigns video in each 'museum path bar' game objects.
    * setLinearImage(): the percentage for each Path are defined


* ProgressBar.cs (Manage the bar in the map interface - Nees to be assigned in each line)
    * min, max assigns the video part for each bar in the map.
    * current, prevFill: Tracking the overall video progress.

---

### Citation
Lee, C., Kim, J., Yi, H., & Lee, W., Viewer2Explorer: Designing a Map Interface for Spatial Navigation in Linear 360 Exhibition Video. (Conditionally Accepted to CHI24).
