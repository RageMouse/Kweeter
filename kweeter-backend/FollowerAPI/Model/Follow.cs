namespace FollowerAPI.Model
{
    public class Follow
    {
        public int Id { get; set; }
        //Persoon die iemand gaat volgen
        public string MainUser { get; set; }
        //Persoon die wordt gevolgd door MainUser
        public string UserFollowed { get; set; }
    }
}
