# Y Drive
Free unlimited file storage using your YouTube account

## News

-January 18, 2018: Pre-release commit of Y Drive! Release Soon!

## Uses

-Storing all of your cat photos.

-Large files that are infrequently accessed. (Up to 128gb files!)

*Do not use for sensitive information*

## Requirements

1. An internet connection?
2. Valid YouTube account.
3. A file to upload.

>**Note:** Your youtube account must allow file uploads of more than 15min for 10GB+ files

## How it works

Upload
1. Drag and drop your file into the main window!
2. Your file is converted to a base64 string and sent for encryption
3. Once your the base64 string is encrypted it is converted into a list of bitmap images
4. This list of bitmap images is converted to a video to store on YouTube for free!
5. A .yd file is saved

Download
1. Drag and drop the .yd file into the main window
2. *Reverse of upload*
3. Your file is ready for use again!


>**Note:** Encryption and Decryption Speeds will vary on different devices.

## Comparison

YDrive against Google Drive:


|                |Google Drive                   |Y Drive                      |
|----------------|-------------------------------|-----------------------------|
|Size limit      |            10 GB              |            128 GB           |
|Storage limit   |            10 GB              |          unlimited          |
|Speed           |           ~50MB/s             |    (Hardware Dependent)     |


## Credits

-https://github.com/keelerh/BigBackup for the idea of using YouTube videos for file storage.
-https://github.com/Tyrrrz/YoutubeExplode for the awesome YouTube library

## Note

This project is under the MIT license and I will hold no accountability for any wrongdoing. Y Drive was created to serve as a useful educational tool for cryptography and steganography on the web. If Google or the YouTube team suggest that this project is in violation of their services then it will be immediately terminated. 