using System.Text;

namespace Урок_1
{
    internal class FamilyMember
    {
        private int age { set; get; }
        private Gender gender { set; get; }
        private string? firstName { set; get; }
        private string? lastName { set; get; }
        private FamilyMember? mother { set; get; }
        private FamilyMember? father { set; get; }
        private FamilyMember? spouce;
        private List<FamilyMember>? childrens { set; get; } = [];
        public int Age { get => age; set => age = value; }
        public Gender Gender { get => gender; set => gender = value; }
        public string? Name { get => firstName; set => firstName = value; }
        public string? LastName { get => lastName; set => lastName = value; }

        public FamilyMember? Mother
        {
            get => mother;
            set
            {

                {
                    if (value != null && value.childrens != null && !value.childrens.Contains(this))
                    {
                        value.childrens.Add(this);
                    }
                    else throw new ArgumentException("Мать уже задана, сначала удалите мать данного ребенка");
                    mother = value;
                }
            }
        }
        public FamilyMember? Father
        {
            get => father;
            set
            {

                {
                    father = value;
                    if (!father.childrens.Contains(this))
                    {
                        father.childrens.Add(this);
                    }
                    else throw new ArgumentException("Отец уже задан, сначала удалите отца данного ребенка");

                }
            }
        }
        public List<FamilyMember>? Childrens { get => childrens; }
        public FamilyMember? Spouce
        {
            get => spouce; set
            {
                if (this.Spouce != value && value != null)
                { spouce = value; }
                else throw new ArgumentException("Такой супруг уже задан, сначала удалите супруга");
                if (value.Spouce != this) value.Spouce = this;
            }
        }
        public FamilyMember()
        {
        }
        public FamilyMember(int age, Gender gender, string? name, string? lastname)
        {
            Age = age;
            Gender = gender;
            Name = name;
            LastName = lastname;
        }

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 20; i++)
                Console.Write('_');
            sb.Append("\n");
            sb.Append("Имя: " + firstName + "\n");
            sb.Append("Фамилия: " + lastName + "\n");
            sb.Append("Возраст: " + age + "\n");
            sb.Append("Пол: " + gender + "\n");
            if (this.mother != null)
                sb.Append("Мать: " + mother?.Name + " " + mother?.LastName + "\n");
            if (this.father != null)
                sb.Append("Отец: " + father?.Name + " " + father?.LastName + "\n");
            if (this.spouce != null)
                sb.Append("Супруг: " + spouce?.Name + " " + spouce?.LastName + "\n");
            if (this.childrens != null)
            {
                sb.AppendLine("Дети:");
                foreach (var child in childrens)
                {
                    sb.AppendLine($"  - {child.Name} {child.LastName}");
                }
            }
            return sb.ToString();
        }

        public List<FamilyMember>? GetGrandMothers() => [mother?.Mother, father?.Mother];
        public List<FamilyMember>? GetGrandFathers() => [mother?.Father, father?.Father];

        public bool SetChild(FamilyMember child)
        {
            if (child == null) throw new ArgumentNullException("Ребенок не существует");
            if (this.Childrens.Contains(child)) throw new ArgumentException("У данного родителя уже существует такой ребенок");
            if (this.Gender == Gender.Male)
            {
                if (child.Father == this) throw new ArgumentException("Родитель уже является отцом данного ребенка");
                child.Father = this;
            }
            else
            {
                if (child.Father == this) throw new ArgumentException("Родитель уже является матерью данного ребенка");
                child.Mother = this;
            }
            return true;
        }

    }
}
