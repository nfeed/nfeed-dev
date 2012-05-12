namespace MCMS
{
    public class database
    {
        //Felder
        private string host;
        private string user;
        private string password;
        private string database;

        public database(string host, string user, string password, string database)
        {
            this.host = host;
            this.user = user;
            this.password = password;
            this.database = database;
        }
    }
}