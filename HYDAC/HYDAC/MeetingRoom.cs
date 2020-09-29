namespace HYDAC
{
    public class MeetingRoom
    {
        private string _name;
        private Pamphlet _pamphlet;
    


        public MeetingRoom(string name, Pamphlet pamphlet)
        {
            this._name = name;
            this._pamphlet = pamphlet;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

     



    }
}
