namespace FirebaseExperiment;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

        // throw exception for testing crash log service.
        if (count == 3)
		{
			Task.Run(() => 
			{
				Task.Delay(3000);
				Console.WriteLine("test exception on background will be thrown.");
                throw new Exception("This is a test exception on background thread."); 
			});
		}

        if (count == 5)
            throw new Exception("This is a test exception on UI Thread.");

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}

