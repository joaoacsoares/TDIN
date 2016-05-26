namespace BankA
{
    public class Ordem
    {
        public int id { get; set; }
        public int clientId { get; set; }
        public int companyId { get; set; }
        public string email { get; set; }
        public int type { get; set; }
        public int quant { get; set; }
        
        public string creationDate { get; set; }
        public string executionDate { get; set; }
        public double valueStock { get; set; }
        public int state { get; set; }

        /*public Ordem (int id, int cli, int comp, string email, int type, int quant,  string Cdate , string Edate, double val, int st)
        {
            this.id = id;
            this.clientId = cli;
            this.email = email;
            this.type = type;
            this.companyId = comp;
            this.creationDate = Cdate;
            this.executionDate = Edate;
            this.valueStock = val;
            this.state = st;
        }*/

    }
}