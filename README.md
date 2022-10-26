# png-segment-password
A winforms application that takes in a user image, segments it into pieces and mixes it within other images. Guessing the image 3 times correctly grants access.
<br/>
The algorithm takes the width and length of the image and creates two arrays which are then used to create points for the rectangles (or squares). The points specify the top right point of the shape (as .NET's winforms' inbuilt graphics device allows to draw rectangles only given the origin point.
<br/>
Finally, the images are seperated into 16 sub-images, creating 256 unique images in total. One of those is of course the password image. To recognize which one is which, a simple class is created, containing the information whether the image segment is indeed part of the password or not.
<br/>
A successful login can be seen below:
<br/>
![DEMO!](https://user-images.githubusercontent.com/62967263/198110892-e4c9a112-3259-4450-9dec-3ba79aa7223d.gif)
