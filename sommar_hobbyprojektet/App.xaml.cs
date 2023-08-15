using sommar_hobbyprojektet.Services;

namespace sommar_hobbyprojektet;

public partial class App : Application
{
    // A public static TodoService property
    public static TodoService PersonRepo { get; private set; }
    public App(TodoService repo)
	{
		InitializeComponent();

		MainPage = new MainPage();
        PersonRepo = repo;
    }
}
