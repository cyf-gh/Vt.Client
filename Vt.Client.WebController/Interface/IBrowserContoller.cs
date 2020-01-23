namespace Vt.Client.WebController {
    public interface IBrowserContoller {
        void Close();
        System.String GetCurrentLocationText();
        void GoToVideoPage();
        void HideVideoControl();
        System.Boolean IsFullScreen();
        System.Boolean IsPause();
        void LocateVideoAtInFullScreenMode( System.String location );
        void LocateVideoBasic( System.String location );
        void Pause();
        void Play();
        void PressEnter();
        void SetFullScreenMode();
        void SetWideScreenMode();
        void ShowVideoControl();
        void TryLogin();

        string LocalCookieFilePath();
        void TryClearUnusedElements();
    }
}