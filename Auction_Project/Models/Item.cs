namespace Auction_Project.Models
{
    public class Item : Entity
    {
        private string m_desc = string.Empty;
        private decimal m_price=0;
        private string m_ImageAddress = string.Empty;   


        public string Desc { 
            get { return m_desc; }
            set { m_desc = value; } }

        public decimal Price {
            get { return m_price; } 
            set { m_price = value; } }

        public string ImagesAddress {
            get { return m_ImageAddress;}
            set { m_ImageAddress = value; }
        }

    }

}
