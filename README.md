# MasonWorm
This is an idea I implemented manually in 2021

![image1](https://i.ibb.co/HwNPKfm/image.png)

But now that I've developed my programming skills, I've created a very simple builder in my favorite language at the time    
The program's concept is to download and run your software via a direct link, download it to %temp%, and then run it     
The idea is that it is secure for the client and cannot remove any program, whatever it may be, because it is not saved in any path on the device but is stored in the cloud in a simple and unnoticeable way

---
One day, I was exploring the registry until I reached the path `Computer\HKEY_CLASSES_ROOT\exefile\shell\open\command`.Upon reaching this path, I discovered that it was the one responsible for running `.exe` files I then tried modifying the value of `"%1" %*` by replacing it with the path to my own file. When I did this, I discovered that changing the value to my own file path would cause it to run whenever any `.exe` file on the computer was opened This is when the idea for this tool came to me, and I worked on it until I achieved this satisfactory result

![image2](https://i.ibb.co/bjFH15LH/image.png)

---
I disclaim all responsibility for any misuse or harmful use of this project in any way
