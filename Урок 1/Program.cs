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
        FamilyMember son = new(20, Gender.Male, "Vasiliy");
        FamilyMember mother = new(40, Gender.Female, "Svetlana");
        FamilyMember father = new(42, Gender.Male, "Alexandr");
        FamilyMember grandMother = new(82, Gender.Female, "Traktorina");
        FamilyMember grandFather = new(82, Gender.Male, "Estahii");

        son.Father = father;
        son.Mother = mother;
        father.Father = grandFather;
        father.Mother = grandMother;

        Console.Write(son);

        son.GetGrandMothers()?.ForEach(g => { Console.Write(g); });

    }
}