using ChannelProcessing;
namespace ChannleProcessing.Tests.ChannelProcessingTests;
public class PerformanceMetricsTests
{
    IPerformanceMetrics metrics = new PerformanceMetrics();

    [Fact]
    public void calculatePerformanceMetricsFromFile_Success()
    {
        var result = metrics.calculatePerformanceMetricsbFromFile(@"TestData/validchannels.txt", @"TestData/validparameters.txt").Result;
        Assert.Equal(6.269852166777007, result);
    }

    [Fact]
    public void calculatePerformanceMetricsFromFile_Invalid_Error()
    {
        Assert.ThrowsAsync<FormatException>(() => metrics.calculatePerformanceMetricsbFromFile(@"TestData/invalidchannels.txt", @"TestData/invalidparameters.txt"));
    }

    [Fact]
    public void calculatePerformanceMetricsFromFile_EmptyPath_Error()
    {
        Assert.ThrowsAsync<ArgumentException>(() => metrics.calculatePerformanceMetricsbFromFile(string.Empty, string.Empty));
    }

    [Fact]
    public void calculatePerformanceMetricsFromFile_EmptyData_Success()
    {
        var result = metrics.calculatePerformanceMetricsbFromFile(@"TestData/emptychannels.txt", @"TestData/emptyparameters.txt").Result;
        Assert.Equal(0, result);
    }

    [Fact]
    public void calculatePerformanceMetricsb_Success()
    {
        var result = metrics.calculatePerformanceMetricsb(new double[] {
            0.3434353433, 0.78347934793, 0.9049384934, 0.49584958945, 0.78934039403, 0.34343434}, new Dictionary<string, double> { { "m", 2.0 }, { "c", 0.5 } }).Result;
        Assert.Equal(3.6349170749950646, result);
    }

    [Fact]
    public void calculatePerformanceMetricsbFromStringContent_Success()
    {
        var result = metrics.calculatePerformanceMetricsbFromStringContent("X, 0.3434353433, 0.78347934793, 0.9049384934, 0.49584958945, 0.78934039403, 0.34343434", "m, 2.0\nc, 0.5").Result;
        Assert.Equal(3.6349170749950646, result);
    }

    [Fact]
    public void calculatePerformanceValueCFromFile_Success()
    {
        var result = metrics.calculatePerformanceValueCFromFile(@"TestData/validchannels.txt", @"TestData/validparameters.txt").Result;

        Assert.Equal(100, result.Length);
        Assert.Equal(new double[] {
            7.084575853170186, 7.175644103852625, 6.396838983070513, 7.183228022916025, 6.902211413002417, 6.367392571776416, 6.548350385644055, 6.8167336859819905, 7.227359002211305, 7.234740701976284, 6.4274652484545545, 7.240444948537623, 7.227019115019953, 6.755227815499848, 7.070132635665806, 6.411738505404221, 6.691613449403282, 7.185587691966074, 7.062059496336561, 7.22934459316991, 6.925592865933593, 6.305563845351196, 7.118981472645784, 7.203845414534557, 6.94858732163478, 7.02759229735534, 7.0129846349019225, 6.662079186311175, 6.9253300569545635, 6.441038854588569, 6.975898254796616, 6.301685013154428, 6.546775151737896, 6.316023557408161, 6.366983948012854, 7.0933099951043, 6.964680789752824, 6.586951646837868, 7.2200742156153614, 6.304298247279916, 6.708596526433404, 6.651410623870015, 7.0353689549260086, 7.06505206791407, 6.456724771331386, 6.759616562565237, 6.715438367487906, 6.9161651768882715, 6.9792169976350795, 7.024538848759367, 6.5458772437755846, 6.949554843630682, 6.924950170750847, 6.432463901971637, 6.388849848335384, 6.768216218759149, 7.229596125293088, 6.61023789344314, 6.855119917756784, 6.4936641062681435, 7.02111922608266, 6.524947282236275, 6.775809218442149, 6.968928889433693, 7.160755419312806, 7.22914359198245, 6.81706769674081, 6.408476609605685, 6.419146172336063, 6.5273604209007425, 7.11056942276067, 6.5241343457485375, 7.084136992845822, 6.513377135501996, 7.199115789964234, 6.6198359327618155, 6.466447417208214, 6.520936024753038, 6.885896842923645, 6.743141015679735, 6.621511673840003, 7.1006807946732975, 6.855116257929731, 6.819575775068147, 7.187045830606817, 6.5556911855973805, 7.027052395887727, 7.023581261055502, 6.650298013752364, 6.837673807502227, 6.3457064563400705, 6.323802285443614, 6.80064971978598, 7.049019396879018, 7.20386285100619, 6.3997583752507365, 6.838675827649199, 6.739242807835213, 6.281754236278248, 6.606974811175888 }, result);
    }
    [Fact]
    public void calculatePerformanceValueC_Success()
    {
        var result = metrics.calculatePerformanceValueC(new double[] {
            0.3434353433, 0.78347934793, 0.9049384934, 0.49584958945, 0.78934039403, 0.34343434}, new Dictionary<string, double> { { "m", 2.0 }, { "c", 0.5 } }).Result;

        Assert.Equal(6, result.Length);
        Assert.Equal(new double[] {
            3.9783524182950645, 4.418396422925064, 4.5398555683950645, 4.130766664445065, 4.424257469025065, 3.9783514149950645}, result);
    }

    [Fact]
    public void calculatePerformanceValueCFromStringContent_Success()
    {
        var result = metrics.calculatePerformanceValueCFromStringContent("X, 0.3434353433, 0.78347934793, 0.9049384934, 0.49584958945, 0.78934039403, 0.34343434", "m, 2.0\nc, 0.5").Result;

        Assert.Equal(6, result.Length);
        Assert.Equal(new double[] {
            3.9783524182950645, 4.418396422925064, 4.5398555683950645, 4.130766664445065, 4.424257469025065, 3.9783514149950645}, result);
    }
}
