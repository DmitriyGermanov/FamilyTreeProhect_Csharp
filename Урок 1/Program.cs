/*
 * Спроектируйте программу для построения генеалогического дерева. 
    Учтите что у нас есть члены семьи у кого нет детей(дет). 
    Есть члены семьи у кого дети есть (взрослые). 
    Есть мужчины и женщины.
*/

using Урок_1;

internal class Program
{
    private static void Main(string[] args)
    {
        FamilyMember son = new(20, Gender.Male, "Vasiliy", "Svetlov");
        FamilyMember daughter = new(18, Gender.Male, "Daria", "Svetlova");
        FamilyMember mother = new(40, Gender.Female, "Svetlana", "Svetlova");
        FamilyMember father = new(42, Gender.Male, "Alexandr", "Svetlov");
        FamilyMember grandMother = new(82, Gender.Female, "Traktorina", "Svetlova");
        FamilyMember grandFather = new(82, Gender.Male, "Estahii", "Svetlov");

        try
        {
            son.Father = father;
            son.Mother = mother;
            father.Spouce = mother;
            father.Father = grandFather;
            father.Mother = grandMother;
            father.SetChild(daughter);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        Console.Write(father);

        son.GetGrandMothers()?.ForEach(g => { Console.Write(g); });

    }
}