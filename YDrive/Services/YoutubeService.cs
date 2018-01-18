using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;

namespace YDrive.Services
{
    public static class YoutubeService
    {
        //collect and send youtube data

        public static async Task UploadVideo(string videoFile, string username, string password)
        {
            UserCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    // This OAuth 2.0 access scope allows an application to upload files to the
                    // authenticated user's YouTube channel, but doesn't allow other types of access.
                    new[] { YouTubeService.Scope.YoutubeUpload },
                    "user",
                    CancellationToken.None
                );
            }

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ""//Find application name
            });

            var video = new Video();
            video.Snippet = new VideoSnippet();
            video.Snippet.Title = "YDRIVE";
            video.Snippet.Description = "This is an encrypted YDRIVE file";
            video.Snippet.Tags = new string[] { "tag1", "tag2" };
            video.Snippet.CategoryId = "22"; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
            video.Status = new VideoStatus();
            video.Status.PrivacyStatus = "unlisted"; // default for nonsearchable videos, could also be("private" or "public")
            var filePath = videoFile; // Replace with path to actual movie file.

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                videosInsertRequest.ProgressChanged += VideosInsertRequest_ProgressChanged;
                videosInsertRequest.ResponseReceived += VideosInsertRequest_ResponseReceived;

                await videosInsertRequest.UploadAsync();
            }
        }



        public static async Task DownloadVideo(string videoID, string filePath)
        {
            var client = new YoutubeClient();
            MediaStreamInfoSet streamInfoSet = await client.GetVideoMediaStreamInfosAsync(videoID);

            var video = await client.GetVideoAsync(videoID);
            var streamInfo = streamInfoSet.Muxed.WithHighestVideoQuality();

            var normalizedFileSize = NormalizeFileSize(streamInfo.Size);


            // Compose file name, based on metadata

            var fileExtension = streamInfo.Container.GetFileExtension();

            var fileName = $"{videoID}.{fileExtension}"; // ???

            //download youtube video, 
            await client.DownloadMediaStreamAsync(streamInfo, filePath);

        }


        /// <summary>

        /// Turns file size in bytes into human-readable string

        /// </summary>

        private static string NormalizeFileSize(long fileSize)
        {
            string[] units = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

            double size = fileSize;

            var unit = 0;

            while (size >= 1024)
            {
                size /= 1024;
                ++unit;
            }
            return $"{size:0.#} {units[unit]}";
        }



        private static void VideosInsertRequest_ProgressChanged(Google.Apis.Upload.IUploadProgress progress)
        {
            switch (progress.Status)
            {
                case UploadStatus.Uploading:
                    Console.WriteLine("{0} bytes sent.", progress.BytesSent);
                    break;

                case UploadStatus.Failed:
                    Console.WriteLine("An error prevented the upload from completing.\n{0}", progress.Exception);
                    break;
            }
        }

        private static void VideosInsertRequest_ResponseReceived(Video video)
        {
            Console.WriteLine("Video id '{0}' was successfully uploaded.", video.Id);
        }


    }
}
