namespace Model
{
    public class SeatModel : AbstractModel
    {
        private int _number;
        private SeatState _state;

        public int Number
        {
            get => _number;
            set => Set(ref _number, value);
        }

        public SeatState State
        {
            get => _state;
            set => Set(ref _state, value);
        }
    }

    public enum SeatState
    {
        Occupied, Free, Chosen
    }
}