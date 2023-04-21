using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using VSTSDataProvider.Common.Helpers;
using VSTSDataProvider.ViewModels.ViewModelBase;

namespace VSTSDataProvider.ViewModels;

public partial class MainWindowViewModel : ViewModelBase.BaseViewModel
{

    public MainWindowViewModel( )
    {
        InitRelayCommand();
    }

    //��ʼ�� RelayCommand ����
    private void InitRelayCommand( )
    {
        MainWindowLoadedCommand = new RelayCommand(MainWindowLoadedMethod);
        GetDataButtonClicked = new AsyncRelayCommand(GetVSTSDataTask);
    }




    #region ���ڽ��� Binding ������ - BindingProperties

    private string? _testPlanID;
    private string? _testSuiteID;
    private string? _completeUrl;
    private string? _cookie;

    public string? TestPlanID
    {
        get => _testPlanID;
        set => SetProperty(ref _testPlanID , value);
    }

    public string? TestSuiteID
    {
        get => _testSuiteID;
        set => SetProperty(ref _testSuiteID , value);
    }

    public string CompleteUrl
    {
        get => _completeUrl ?? string.Empty;
        set => SetProperty(ref _completeUrl , value);
    }

    public string Cookie
    {
        get => _cookie ?? string.Empty;
        set => SetProperty(ref _cookie , value);
    }

    #endregion ���ڽ��� Binding ������ - BindingProperties


    #region ���ڽ��� Binding ������ - RelayCommands
    public ICommand MainWindowLoadedCommand { get; set; }

    private void MainWindowLoadedMethod( )
    {
        bool hello = DataObjectsHelper.IsDefault<string>(null);
    }


    public ICommand GetDataButtonClicked { get; set; }
    private bool CanGetData(object param)
    {
        bool IDandCookie = !string.IsNullOrEmpty(TestPlanID) && !string.IsNullOrEmpty(TestSuiteID) && !string.IsNullOrEmpty(Cookie);
        bool UrlandCookie = !string.IsNullOrEmpty(CompleteUrl) && !string.IsNullOrEmpty(Cookie);
        return IDandCookie || UrlandCookie;
    }

    private Task GetVSTSDataTask(CancellationToken cts)
    {

    }
    #endregion ���ڽ��� Binding ������ - RelayCommands

}