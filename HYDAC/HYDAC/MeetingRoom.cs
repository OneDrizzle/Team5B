namespace HYDAC
{
    public class MeetingRoom
    {
        private string name;
        private Pamphlet pamphlet;
    


        public MeetingRoom(string name, Pamphlet pamphlet)
        {
            this.name = name;
            this.pamphlet = pamphlet;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public Pamphlet Pamphlet
        {
            get
            {
                return pamphlet;
            }
        }

     



    }
}
