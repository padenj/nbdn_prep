namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface Criteria<Item>
    {
        bool is_satisfied_by(Item item);
    }
}