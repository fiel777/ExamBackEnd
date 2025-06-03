namespace ExamApplication.Entity
{
    public class FruitInventory
    {

        public int Id { get; set; }
        public required string Name { get; set; }

        public required string Type { get; set; }
        public required int Price { get; set; }
        public required int Stock { get; set; }

    }
  

}

