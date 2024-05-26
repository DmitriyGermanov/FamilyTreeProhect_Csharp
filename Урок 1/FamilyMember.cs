using System.Text;

namespace Урок_1
{
    internal class FamilyMember
    {
        private int age { set; get; }
        private Gender gender { set; get; }
        private string? firstName { set; get; }
        private FamilyMember? mother { set; get; }
        private FamilyMember? father { set; get; }
        private FamilyMember? spouce;
        private List<FamilyMember>? childrens { set; get; }
        public int Age { get => age; set => age = value; }
        public Gender Gender { get => gender; set => gender = value; }
        public string? Name { get => firstName; set => firstName = value; }
        public FamilyMember? Mother { get => mother; set => mother = value; }
        public FamilyMember? Father { get => father; set => father = value; }
        public FamilyMember? Spouce { get => spouce; set => spouce = value; }
        public List<FamilyMember>? Childrens { get => childrens; set => childrens = value; }

        public FamilyMember()
        {
        }
        public FamilyMember(int age, Gender gender, string? name)
        {
            Age = age;
            Gender = gender;
            Name = name;
        }



        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 20; i++)
                Console.Write('_');
            sb.Append("\n");
            sb.Append("Имя: " + firstName + "\n");
            sb.Append("Возраст: " + age + "\n");
            sb.Append("Пол: " + gender + "\n");
            if(this.mother != null)
            sb.Append("Мать: " + mother?.Name + "\n");
            if(this.father != null)
            sb.Append("Отец: " + father?.Name + "\n");
            if(this.spouce != null)
            sb.Append("Супруг: " + spouce?.Name + "\n");
            if (this.childrens != null)
            {
                sb.Append("Дети: " + "\n");
                childrens?.ForEach(c => sb.Append(c.Name + ", "));
            }
            return sb.ToString();
        }

        public List<FamilyMember>? GetGrandMothers() => [mother?.Mother, father?.Mother];
        public List<FamilyMember>? GetGrandFathers() => [mother?.Father, father?.Father];


    }
}
