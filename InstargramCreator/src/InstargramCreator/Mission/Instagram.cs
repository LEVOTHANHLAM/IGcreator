using InstargramCreator.Entities;
using InstargramCreator.Files;
using InstargramCreator.Input;
using InstargramCreator.Models;
using InstargramCreator.MultiTask;
using InstargramCreator.Repositories;
using LDPlayerNTC;
using Serilog;

namespace InstargramCreator.Mission
{
    public class Instagram
    {
        private readonly IAccountRepository _accountRepository;
        private string packageInstagram = "com.instagram.lite";
        private string packageGallery = "com.android.gallery3d";
        public Instagram(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public void Auto(int Index, MailInfoModel mail, FullNameInfoModel fullNameInfo, UserInfoModel userInfo, BioInfoModel bio, AvatarInfoModel avatar, PostInfoModel post)
        {
            try
            {
                LDController.ClearCaches("index", Index.ToString(), packageInstagram);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Clear Caches Instagram ");
                LDController.Delay();
                LDController.RunApp("index", Index.ToString(), packageInstagram);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Run App Instagram ");
                LDController.Delay(35, 40);
                AutoInstagram(Index, mail, fullNameInfo, userInfo);
                if (mail.Status == true)
                {
                    if (mail.Proxy == null)
                    {
                        mail.Proxy = "";
                    }
                    Accounts accounts = new Accounts();
                    accounts.Id = Guid.NewGuid();
                    if (TextInfoModel.cbCatch == true)
                    {
                        accounts.Email = mail.EmailForm;
                    }
                    else
                    {
                        accounts.Email = mail.Email;
                    }
                    accounts.Password = mail.PassInstargram;
                    accounts.UserName = mail.User;
                    accounts.Proxy = mail.Proxy;
                    accounts.FullName = mail.FullName;
                    accounts.CreateDate = DateTime.Now;
                    _accountRepository.Add(accounts);
                    GlobalModel.rtbResultQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + mail.Email + "," + mail.PassInstargram + "," + mail.User + "," + mail.Proxy + "_" + mail.FullName);
                    GlobalModel.createAccount++;
                    if (RadioInfoModel.radioNoProxy == false)
                    {
                        GlobalModel.ListProxy.Add(mail.Proxy);
                    }
                    GlobalModel.ListEmail.Add(mail.Email);
                    if (RadioInfoModel.radioFullnameCustomize == true)
                    {
                        GlobalModel.ListFullName.Add(mail.FullName);
                    }
                    if (RadioInfoModel.radioUserCustomize == true)
                    {
                        GlobalModel.ListUserName.Add(mail.User);
                    }
                    if (RadioInfoModel.cbAvatar == true)
                    {
                        UploadAvartar(Index, avatar);
                    }
                    if (RadioInfoModel.cbPost == true)
                    {
                        UploadPost(Index, post);
                    }
                    if (RadioInfoModel.cbBio == true)
                    {
                        UploadBio(Index, bio);
                    }
                    LDController.Key("index", Index.ToString(), ADBKeyEvent.KEYCODE_HOME);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") +"Error " + " LDPlayer  " + Index + " " + ex.Message);
                LDController.Close("index", Index.ToString());
            }
        }
        private async void AutoInstagram(int Index, MailInfoModel mail, FullNameInfoModel fullNameInfo, UserInfoModel userInfo)
        {
            if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.CreateNewAccount, 200000) == true)
            {
                LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.CreateNewAccount);
                LDController.Delay();
                if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.Next) == true)
                {
                    LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.Email);
                    LDController.Delay();
                    if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.Next) == true)
                    {
                        if(TextInfoModel.cbCatch == true)
                        {
                            ReadFileJson readFileJson = new ReadFileJson();
                            var firstName = readFileJson.GetStringFileJson(GlobalModel.PathUserNameJsoin);
                            mail.EmailForm = firstName + RandomStrings.RandomAllString(RandomStrings.RandomNumber(4, 10), RandomStrings.Numeric + RandomStrings.LowerCase)+mail.Email;
                            LDController.InputText("index", Index.ToString(), mail.EmailForm);
                            GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Import Email: " + mail.EmailForm);
                            Log.Information("LDPlayer " + Index + " Import Email: " + mail.EmailForm);
                        }
                        else
                        {
                            LDController.InputText("index", Index.ToString(), mail.Email);
                            GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Import Email: " + mail.Email);
                        }
                        Log.Information("LDPlayer " + Index + " Import Email: " + mail.EmailForm);
                        LDController.Delay();
                        LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.Next);
                        LDController.Delay();
                        if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.ScreenshotCreateNewAccountTB) == true)
                        {
                            GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Unable to continue because this Email has been registered before ");
                            LDController.Close("index", Index.ToString());
                            return;
                        }
                        if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.Next) == true)
                        {
                            if (TextInfoModel.cbCatch == true)
                            {
                                Log.Information("LDPlayer " + Index + " Import Email: " + mail.EmailForm);
                                LDController.Delay(40,60);
                                string otp = MailKits.VerifyMail(mail.Email, mail.PassMail, mail.Imap, mail.PortImap, mail.EmailForm, "Instagram");
                                LDController.Delay();
                                LDController.InputText("index", Index.ToString(), otp);
                                LDController.Delay();
                                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Import Otp: " + otp);
                            }
                            else
                            {
                                string otp = MailKits.VerifyMail(mail.Email, mail.PassMail, mail.Imap, mail.PortImap, mail.Email, "Instagram");
                                LDController.Delay();
                                LDController.InputText("index", Index.ToString(), otp);
                                LDController.Delay();
                                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Import Otp: " + otp);
                            }

                            LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.Next);
                            LDController.Delay(10, 20);
                        }
                        if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.Name) == true)
                        {
                            if (RadioInfoModel.radioFullnameCustomize == true)
                            {
                                ReadFileJson readFileJson = new ReadFileJson();
                                fullNameInfo.FirstName = readFileJson.GetStringsFileTxt(TextInfoModel.txtFullname);
                                fullNameInfo.LastName = readFileJson.GetStringsFileTxt(TextInfoModel.txtLastName);
                                mail.FullName = fullNameInfo.FirstName +"%s" +fullNameInfo.LastName;
                            }
                            else if(RadioInfoModel.radioFullnameRandom == true)
                            {
                                ReadFileJson readFileJson = new ReadFileJson();
                                fullNameInfo.FirstName = readFileJson.GetStringFileJson(GlobalModel.PathFistNameJsoin);
                                fullNameInfo.LastName = readFileJson.GetStringFileJson(GlobalModel.PathLastNameJsoin);
                                string fullName = fullNameInfo.FirstName + "%s" + fullNameInfo.LastName;
                                mail.FullName = fullName;
                            }else if (RadioInfoModel.radioRandomVN == true)
                            {
                                ReadFileJson readFileJson = new ReadFileJson();
                                fullNameInfo.FirstName = readFileJson.GetStringsFileTxt(GlobalModel.PathFullnameVNJsion);
                                fullNameInfo.LastName = readFileJson.GetStringsFileTxt(GlobalModel.PathFullnameVNJsion);
                                mail.FullName = fullNameInfo.FirstName + "%s" + fullNameInfo.LastName;
                            }
                            LDController.TapByPercent("index", Index.ToString(), 10.3, 19.8);
                            LDController.InputText("index", Index.ToString(), "B");
                            LDController.InputText("index", Index.ToString(),string.Format("'{0}'", mail.FullName));
                            LDController.TapByPercent("index", Index.ToString(), 9.4, 20.8);
                            LDController.Key("index",Index.ToString(),ADBKeyEvent.KEYCODE_DEL);
                            LDController.Delay();
                            GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Import FullName: " + mail.FullName);
                            if (RadioInfoModel.radioPasswordCustomize == true)
                            {
                                mail.PassInstargram = TextInfoModel.txtPasswordCustomize;
                            }
                            else
                            {
                                string chartext = RandomStrings.LowerCase + RandomStrings.UpperCase + RandomStrings.Numeric + RandomStrings.Special;
                                var number = TextInfoModel.txtPasswordRandom;
                                mail.PassInstargram = RandomStrings.RandomAllString(number, chartext);
                            }
                            LDController.TapByPercent("index", Index.ToString(), 9.4, 33.1);
                            LDController.InputText("index", Index.ToString(), mail.PassInstargram);
                            LDController.Delay();
                            GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Import Password: " + mail.PassInstargram);
                            LDController.TapByPercent("index", Index.ToString(), 39.8, 51.8);
                            LDController.Delay();
                            if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.Allow) == true)
                            {
                                LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.Allow);
                                LDController.Delay();
                            }
                            else if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.ScreenshotNotNow) == true)
                            {
                                LDController.TapByPercent("index", Index.ToString(), 47.6, 65.0);
                                LDController.Delay();
                            }
                            if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.Next) == true)
                            {
                                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Your date of birth ");
                                int bithday = RandomStrings.RandomNumber(7, 11);
                                for (int i = 0; i < bithday; i++)
                                {
                                    LDController.SwipeByPercent("index", Index.ToString(), 82.2, 77.5, 82.2, 65.8);
                                    LDController.SwipeByPercent("index", Index.ToString(), 48.8, 77.7, 48.8, 65.5);
                                    LDController.SwipeByPercent("index", Index.ToString(), 14.8, 77.7, 15.4, 66.6);
                                    LDController.Delay();
                                }
                                {
                                    LDController.TapByPercent("index", Index.ToString(), 82.5, 59.0);
                                    LDController.TapByPercent("index", Index.ToString(), 81.9, 61.3);
                                    LDController.TapByPercent("index", Index.ToString(), 48.8, 59.5);
                                    LDController.TapByPercent("index", Index.ToString(), 49.1, 62.6);
                                    LDController.TapByPercent("index", Index.ToString(), 16.0, 59.5);
                                    LDController.TapByPercent("index", Index.ToString(), 15.4, 62.1);
                                    LDController.Delay();
                                }
                                LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.Next);
                                LDController.Delay();
                            }
                            if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.Next) == true)
                            {
                                LDController.FindImageTapUserName("index", Index.ToString(), ImagesInfoModel.Next);
                                LDController.Delay();
                                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Change UserName ");
                                if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.Next) == true)
                                {
                                    LDController.LongPress("index", Index.ToString(), 50, 280, 3000);
                                    LDController.Key("index", Index.ToString(), ADBKeyEvent.KEYCODE_DEL);
                                    LDController.Delay();
                                    if (RadioInfoModel.radioUserCustomize == false)
                                    {
                                        ReadFileJson readFileJson = new ReadFileJson();
                                        string username = readFileJson.GetStringFileJson(GlobalModel.PathUserNameJsoin);
                                        int number = RandomStrings.RandomNumber(5, 10);
                                        string charText = RandomStrings.LowerCase + RandomStrings.Numeric;
                                        mail.User = username + RandomStrings.RandomAllString(number, charText);
                                    }
                                    else
                                    {
                                        mail.User = userInfo.UserName;
                                    }
                                    LDController.InputText("index", Index.ToString(), mail.User);
                                    LDController.Delay(10, 15);
                                    GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Import UserName: " + mail.User);
                                    LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.Next);
                                    LDController.Delay(15, 20);
                                    if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.Continue) == true)
                                    {
                                        LDController.Close("index", Index.ToString());
                                        GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + "LDPlayer " + Index + " Unable to continue ");
                                        return;
                                    }
                                    else if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.ScreenshotTryAgainLater) == true)
                                    {
                                        LDController.Close("index", Index.ToString());
                                        GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "Error " + "LDPlayer " + Index + " Unable to continue ");
                                        return;
                                    }
                                    else if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.Next) == true)
                                    {
                                        LDController.FindImageTapPublic("index", Index.ToString(), ImagesInfoModel.Next);
                                        LDController.Delay();
                                        LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.Next);
                                        LDController.Delay(10, 20);
                                    }
                                    if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.Skip) == true)
                                    {
                                        LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.Skip);
                                        LDController.Delay(15, 20);
                                        mail.Status = true;
                                        GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Successfully created Instagram account ");
                                    }
                                    if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.User1) == true)
                                    {
                                        LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.User1);
                                        LDController.Delay();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void UploadBio(int Index, BioInfoModel bio)
        {
            if (bio != null)
            {
                if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.Posts) == true)
                {
                    GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Upload Bio ");
                    LDController.FindImageTapEditProfile("index", Index.ToString(), ImagesInfoModel.Posts);
                    LDController.Delay();
                    LDController.TapByPercent("index", Index.ToString(), 6.1, 73.1);
                    LDController.Delay();
                    LDController.TapByPercent("index", Index.ToString(), 16.6, 21.3);
                    LDController.Delay();
                    LDController.InputText("index", Index.ToString(), bio.Bio);
                    LDController.Delay();
                    GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Import Bio: " + bio.Bio);
                    LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.Save);
                    LDController.Delay();
                    LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.Save);
                    LDController.Delay();
                    GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Upload Bio successful ");
                }
            }
        }
        private void UploadAvartar(int Index, AvatarInfoModel avatar)
        {
            if (avatar != null && !string.IsNullOrEmpty(avatar.NameImg) && !string.IsNullOrEmpty(avatar.Img))
            {
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Upload Avatar ");
                LDController.PushImages("index", Index.ToString(), avatar.Img);
                LDController.Delay(15, 20);
                LDController.Key("index", Index.ToString(), ADBKeyEvent.KEYCODE_HOME);
                LDController.Delay();
                LDController.RunApp("index", Index.ToString(), packageGallery);
                LDController.Delay();
                LDController.Key("index", Index.ToString(), ADBKeyEvent.KEYCODE_HOME);
                LDController.Delay();
                LDController.RunApp("index", Index.ToString(), packageInstagram);
                LDController.Delay();
                if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.Posts, 40000) == true)
                {                  
                    LDController.FindImageTapEditProfile("index", Index.ToString(), ImagesInfoModel.Posts);
                    LDController.Delay();
                    if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.ChangePhoto, 40000) == true)
                    {
                        LDController.FindImageTapChangePhoto("index", Index.ToString(), ImagesInfoModel.ChangePhoto);
                        LDController.Delay();
                        LDController.TapByPercent("index", Index.ToString(), 6.4, 88.3);
                        LDController.Delay();
                        if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.ContinuePhoto, 40000) == true)
                        {
                            LDController.TapByPercent("index", Index.ToString(), 47.3, 85.1);
                            LDController.Delay();
                            LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.Allow);
                            LDController.Delay();
                        }
                        LDController.TapByPercent("index", Index.ToString(), 18.7, 18.7);
                        LDController.Delay();
                        LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.Save);
                        LDController.Delay(15, 30);
                        if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.OK) == true)
                        {
                            LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.OK);
                            LDController.Delay(15, 30);
                            GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Upload Avatar successful ");
                        }
                        LDController.ADB("index", Index.ToString(), " shell rm -f /mnt/shared/Pictures/" + avatar.NameImg);
                        LDController.Delay();
                    }
                }
            }
        }
        private void UploadPost(int Index, PostInfoModel post)
        {
            if (post != null && !string.IsNullOrEmpty(post.NameImg) && !string.IsNullOrEmpty(post.Img))
            {
                GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Upload Post ");
                LDController.PushImages("index", Index.ToString(), post.Img);
                LDController.Delay(15, 20);
                if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.Posts) == true)
                {
                    int postS = RandomStrings.RandomNumber(2);
                    for (int i = 0; i < postS; i++)
                    {
                        LDController.SwipeByPercent("index", Index.ToString(), 47.9, 43.0, 57.2, 24.0);
                        LDController.Delay();
                    }
                    if (LDController.FindImage("index", Index.ToString(), ImagesInfoModel.No) == true)
                    {
                        LDController.FindImageTap("index", Index.ToString(), ImagesInfoModel.No);
                        LDController.Delay();
                    }
                    LDController.TapByPercent("index", Index.ToString(), 48.2, 87.0);
                    LDController.Delay();
                    LDController.TapByPercent("index", Index.ToString(), 93.6, 22.0);
                    LDController.Delay();
                    LDController.TapByPercent("index", Index.ToString(), 90.0, 6.0);
                    LDController.Delay();
                    LDController.TapByPercent("index", Index.ToString(), 90.0, 6.0);
                    LDController.Delay();
                    LDController.TapByPercent("index", Index.ToString(), 25.3, 16.0);
                    LDController.InputText("index", Index.ToString(), post.Post);
                    LDController.Delay();
                    GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Write a caption... ");
                    LDController.TapByPercent("index", Index.ToString(), 89.1, 6.0);
                    LDController.Delay();
                    GlobalModel.rtbLogsQueue.Enqueue(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss\t") + "LDPlayer " + Index + " Upload Post successful ");
                }
            }
        }
    }
}       