namespace Lake.Interfaces
{

    public interface IControllable
    {
        void Callback_OnButtonXPressed();
        void Callback_OnButtonXReleased();
        void Callback_OnButtonYPressed();
        void Callback_OnButtonYReleased();
        void Callback_OnButtonAPressed();
        void Callback_OnButtonAReleased();
        void Callback_OnButtonBPressed();
        void Callback_OnButtonBReleased();
        void Callback_OnLeftBumperPressed();
        void Callback_OnLeftBumperReleased();
        void Callback_OnRightBumperPressed();
        void Callback_OnRightBumperReleased();
        void Callback_OnDPadUpPressed();
        void Callback_OnDPadUpReleased();
        void Callback_OnDPadDownPressed();
        void Callback_OnDPadDownReleased();
        void Callback_OnDPadLeftPressed();
        void Callback_OnDPadLeftReleased();
        void Callback_OnDPadRightPressed();
        void Callback_OnDPadRightReleased();
        void Callback_OnLeftTriggerPressed();
        void Callback_OnLeftTriggerReleased();
        void Callback_OnRightTriggerPressed();
        void Callback_OnRightTriggerReleased();
    }

}