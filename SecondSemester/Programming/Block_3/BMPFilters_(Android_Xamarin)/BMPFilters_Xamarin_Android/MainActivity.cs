using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace BMPFilters_Xamarin_Android
{
    [Activity(Label = "BMP Filters", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            
            // Кнопки, отвечающие за переключение картинок.
            var buttonOriginal = FindViewById<Button>(Resource.Id.button1);
            var buttonSobelY = FindViewById<Button>(Resource.Id.button4);
            var buttonSobelX = FindViewById<Button>(Resource.Id.button5);
            var buttonMedian = FindViewById<Button>(Resource.Id.button6);
            var buttonGray = FindViewById<Button>(Resource.Id.button7);
            var buttonGauss = FindViewById<Button>(Resource.Id.button8);
            
            // И сами картинки.
            var imageOriginal = (ImageView)FindViewById(Resource.Id.myImage);
            imageOriginal.Visibility = ViewStates.Visible;
            var imageSobelY = (ImageView)FindViewById(Resource.Id.myImage2);
            imageSobelY.Visibility = ViewStates.Invisible;
            var imageSobelX = (ImageView)FindViewById(Resource.Id.myImage3);
            imageSobelX.Visibility = ViewStates.Invisible;
            var imageMedian = (ImageView)FindViewById(Resource.Id.myImage4);
            imageMedian.Visibility = ViewStates.Invisible;
            var imageGray = (ImageView)FindViewById(Resource.Id.myImage5);
            imageGray.Visibility = ViewStates.Invisible;
            var imageGauss = (ImageView) FindViewById(Resource.Id.myImage6);
            imageGauss.Visibility = ViewStates.Invisible;
            
            // Отображение оригинальной картинки.
            buttonOriginal.Click += (o, e) =>
            {
                Toast.MakeText(this, "Это оригинальный фильтр:", ToastLength.Short).Show();
                imageOriginal.Visibility = ViewStates.Visible;
                imageSobelY.Visibility = ViewStates.Invisible;
                imageSobelX.Visibility = ViewStates.Invisible;
                imageMedian.Visibility = ViewStates.Invisible;
                imageGray.Visibility = ViewStates.Invisible;
                imageGauss.Visibility = ViewStates.Invisible;
            };
            
            // Отображение картинки, к которой применен фильтр SobelX.
            buttonSobelX.Click += (o, e) =>
            {
                Toast.MakeText(this, "Это фильтр SobelX:", ToastLength.Short).Show();
                imageOriginal.Visibility = ViewStates.Invisible;
                imageSobelY.Visibility = ViewStates.Invisible;
                imageSobelX.Visibility = ViewStates.Visible;
                imageMedian.Visibility = ViewStates.Invisible;
                imageGray.Visibility = ViewStates.Invisible;
                imageGauss.Visibility = ViewStates.Invisible;
            };
            
            // Отображение картинки, к которой применен фильтр SobelY.
            buttonSobelY.Click += (o, e) =>
            {
                Toast.MakeText(this, "Это фильтр SobelY:", ToastLength.Short).Show();
                imageOriginal.Visibility = ViewStates.Invisible;
                imageSobelY.Visibility = ViewStates.Visible;
                imageSobelX.Visibility = ViewStates.Invisible;
                imageMedian.Visibility = ViewStates.Invisible;
                imageGray.Visibility = ViewStates.Invisible;
                imageGauss.Visibility = ViewStates.Invisible;
            };
            
            // Отображение картинки, к которой применен фильтр Median.
            buttonMedian.Click += (o, e) =>
            {
                Toast.MakeText(this, "Это фильтр Median:", ToastLength.Short).Show();
                imageOriginal.Visibility = ViewStates.Invisible;
                imageSobelY.Visibility = ViewStates.Invisible;
                imageSobelX.Visibility = ViewStates.Invisible;
                imageMedian.Visibility = ViewStates.Visible;
                imageGray.Visibility = ViewStates.Invisible;
                imageGauss.Visibility = ViewStates.Invisible;
            };
            
            // Отображение картинки, к которой применен фильтр Gray.
            buttonGray.Click += (o, e) =>
            {
                Toast.MakeText(this, "Это фильтр Gray:", ToastLength.Short).Show();
                imageOriginal.Visibility = ViewStates.Invisible;
                imageSobelY.Visibility = ViewStates.Invisible;
                imageSobelX.Visibility = ViewStates.Invisible;
                imageMedian.Visibility = ViewStates.Invisible;
                imageGray.Visibility = ViewStates.Visible;
                imageGauss.Visibility = ViewStates.Invisible;
            };
            
            // Отображение картинки, к которой применен фильтр Gauss.
            buttonGauss.Click += (o, e) =>
            {
                Toast.MakeText(this, "Это фильтр Gauss:", ToastLength.Short).Show();
                imageOriginal.Visibility = ViewStates.Invisible;
                imageSobelY.Visibility = ViewStates.Invisible;
                imageSobelX.Visibility = ViewStates.Invisible;
                imageMedian.Visibility = ViewStates.Invisible;
                imageGray.Visibility = ViewStates.Invisible;
                imageGauss.Visibility = ViewStates.Visible;
            };
            
            // Отображение информации о приложении.
            var buttonInfo = FindViewById<Button>(Resource.Id.button10);
            buttonInfo.Click += (o, e) =>
            {
                var text = "Это тестировочное приложение, демонстрирующее работу фильтров на одной картинке. Полная " +
                           "версия приложения доступна на моем GitHub'е: github.com/lastdesire под " +
                           "Windows.";
                Toast.MakeText(this, text, ToastLength.Long).Show();
            };

        }
        
        
        
    }

    
    
    
}