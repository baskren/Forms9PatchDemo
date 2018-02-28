using System;

using Xamarin.Forms;
using P42.Utils;
using System.Linq;
using System.Collections.Generic;
using Forms9Patch;
using System.Reflection;
using System.Diagnostics;

namespace Forms9PatchDemo
{
    public class ClipboardTest : ContentPage
    {
        static int seed = 3452;
        readonly static Random _rand = new Random(seed);

        StatusLabel _byteTest = new StatusLabel("byte test ");
        StatusLabel _byteArrayTest = new StatusLabel("byte[] test ");
        StatusLabel _charTest = new StatusLabel("char test ");
        StatusLabel _shortTest = new StatusLabel("short test ");
        StatusLabel _intTest = new StatusLabel("int test ");
        StatusLabel _longTest = new StatusLabel("long test ");
        StatusLabel _doubleTest = new StatusLabel("double test ");
        StatusLabel _stringTest = new StatusLabel("string test ");
        StatusLabel _intListTest = new StatusLabel("List&lt;int&gt; test ");
        StatusLabel _doubleListTest = new StatusLabel("List&lt;double&gt; test ");
        StatusLabel _stringListTest = new StatusLabel("List&lt;string&gt; test ");
        StatusLabel _dictionaryTest = new StatusLabel("Dictionary&lt;string,double&gt; test ");
        StatusLabel _dictionaryListTest = new StatusLabel("List&lt;Dictionary&lt;string,double&gt;&gt; test ");

        Xamarin.Forms.Label _elapsedTimeLabel = new Xamarin.Forms.Label();

        Xamarin.Forms.StackLayout _layout = new Xamarin.Forms.StackLayout
        {
            Children = { new Forms9Patch.Label("<b>Copy / Paste tests:</b>") }
        };

        Switch _entryCaching = new Switch { HorizontalOptions = LayoutOptions.End };
        //Switch _entryItemTypeCaching = new Switch { HorizontalOptions = LayoutOptions.End };
        Xamarin.Forms.Button _execute = new Xamarin.Forms.Button
        {
            Text = "run test"
        };

        public ClipboardTest()
        {
            Padding = new Thickness(20, Device.RuntimePlatform == Device.iOS ? 40 : 20, 20, 0);

            _entryCaching.IsToggled = Clipboard.EntryCaching;
            //_entryItemTypeCaching.IsToggled = Clipboard.EntryItemTypeCaching;

            _entryCaching.Toggled += (sender, e) => Clipboard.EntryCaching = _entryCaching.IsToggled;
            //_entryItemTypeCaching.Toggled += (sender, e) => Clipboard.EntryItemTypeCaching = _entryItemTypeCaching.IsToggled;

            _layout.Children.Add(_byteTest);
            _layout.Children.Add(_byteArrayTest);
            _layout.Children.Add(_shortTest);
            _layout.Children.Add(_intTest);
            _layout.Children.Add(_longTest);
            _layout.Children.Add(_doubleTest);
            _layout.Children.Add(_stringTest);
            _layout.Children.Add(_intListTest);
            _layout.Children.Add(_doubleListTest);
            _layout.Children.Add(_stringListTest);
            _layout.Children.Add(_dictionaryTest);
            _layout.Children.Add(_dictionaryListTest);
            _layout.Children.Add(new BoxView { Color = Color.Blue, HeightRequest = 5 });
            _layout.Children.Add(new Forms9Patch.Label("Entry caching:"));
            _layout.Children.Add(_entryCaching);
            //_layout.Children.Add(new Forms9Patch.Label("EntryItem type caching:"));
            //_layout.Children.Add(_entryItemTypeCaching);
            _layout.Children.Add(_execute);
            _layout.Children.Add(new BoxView { Color = Color.Blue, HeightRequest = 5 });
            _layout.Children.Add(_elapsedTimeLabel);

            Content = new ScrollView
            {
                Content = _layout
            };

            _execute.Clicked += (sender, e) => CopyPaste();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Keep in mind, event handlers can be zombies.  Think about proper disposal (or squelching) if you want to be sure it doesn't appear after you leave the page/view where you instantiated it.
            Clipboard.ContentChanged += Clipboard_ContentChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Clipboard.ContentChanged -= Clipboard_ContentChanged;
        }

        void Clipboard_ContentChanged(object sender, EventArgs e)
        {
            Forms9Patch.Toast.Create("CHANGED!", "The clipboard has changed");
        }


        bool CopyPaste()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var entry = new Forms9Patch.ClipboardEntry();


            var testByteArray = new byte[200];
            _rand.NextBytes(testByteArray);
            entry.AddValue("application/x-forms9patchdemo-byte", testByteArray[0]);
            entry.AddValue("application/x-forms9patchdemo-bytebuffer", testByteArray);
            var t = stopWatch.ElapsedMilliseconds;
            System.Diagnostics.Debug.WriteLine("t=[" + t + "]");
            var lastT = t;


            var testChar = (char)_rand.Next(255);
            entry.AddValue("application/x-forms9patchdemo-char", testChar);
            t = stopWatch.ElapsedMilliseconds;
            System.Diagnostics.Debug.WriteLine("t=[" + t + "] delta=[" + (t - lastT) + "]");
            lastT = t;

            var testShort = (short)_rand.Next(255);
            entry.AddValue("application/x-forms9patchdemo-short", testShort);
            t = stopWatch.ElapsedMilliseconds;
            System.Diagnostics.Debug.WriteLine("t=[" + t + "] delta=[" + (t - lastT) + "]");
            lastT = t;

            var testInt = _rand.Next();
            entry.AddValue("application/x-forms9patchdemo-int", testInt);
            t = stopWatch.ElapsedMilliseconds;
            System.Diagnostics.Debug.WriteLine("t=[" + t + "] delta=[" + (t - lastT) + "]");
            lastT = t;

            var testLong = (long)_rand.Next() + (long)int.MaxValue;
            entry.AddValue("application/x-forms9patchdemo-long", testLong);
            t = stopWatch.ElapsedMilliseconds;
            System.Diagnostics.Debug.WriteLine("t=[" + t + "] delta=[" + (t - lastT) + "]");
            lastT = t;

            var testDouble = _rand.NextDouble();
            entry.AddValue("application/x-forms9patchdemo-double", testDouble);
            t = stopWatch.ElapsedMilliseconds;
            System.Diagnostics.Debug.WriteLine("t=[" + t + "] delta=[" + (t - lastT) + "]");
            lastT = t;

            var testString = "This is application/x-forms9patchdemo-string: ⅓ ⅔ ⓪ ① ② ③ ④ ⑤ ⑥ ⑦ ⑧ ⑨ ⑩ ⑪ ⑫ ⑬ ⑭ ⑮ ⑯ ⑰ ⑱ ⑲ ⑳  🅰 🅱 🅲 🅳 🅴 🅵 🅶 🅷 🅸 🅹 🅺 🅻 🅼 🅽 🅾 🅿 🆀 🆁 🆂 🆃 🆄 🆅 🆆 🆇 🆈 🆉 🙃 😐 😑 🤔 🙄 😮 😔 😖 😕";
            entry.AddValue("application/x-forms9patchdemo-string", testString);
            t = stopWatch.ElapsedMilliseconds;
            System.Diagnostics.Debug.WriteLine("t=[" + t + "] delta=[" + (t - lastT) + "]");
            lastT = t;

            var testIntList = new List<int>();
            for (int i = 0; i < 20; i++)
                testIntList.Add(i);
            entry.AddValue("application/x-forms9patchdemo-int-list", testIntList);
            t = stopWatch.ElapsedMilliseconds;
            System.Diagnostics.Debug.WriteLine("t=[" + t + "] delta=[" + (t - lastT) + "]");
            lastT = t;

            var testDoubleList = new List<double>();
            for (int i = 0; i < 20; i++)
                testDoubleList.Add(i + i / 10.0);
            entry.AddValue("application/x-forms9patchdemo-double-list", testDoubleList);
            t = stopWatch.ElapsedMilliseconds;
            System.Diagnostics.Debug.WriteLine("t=[" + t + "] delta=[" + (t - lastT) + "]");
            lastT = t;

            var testStringList = new List<string>();
            for (int i = 0; i < 20; i++)
                testStringList.Add(RandomString(10));
            entry.AddValue("application/x-forms9patchdemo-string-list", testStringList);
            t = stopWatch.ElapsedMilliseconds;
            System.Diagnostics.Debug.WriteLine("t=[" + t + "] delta=[" + (t - lastT) + "]");
            lastT = t;


            var testDictionary = new Dictionary<string, double>();
            for (int i = 0; i < 20; i++)
                testDictionary.Add(RandomString(10), i + i / 10.0);
            entry.AddValue("application/x-forms9patchdemo-dictionary", testDictionary);

            var testDictionaryList = new List<Dictionary<string, string>>();
            var keys = testDictionary.Keys;
            for (int i = 0; i < 20; i++)
            {
                var dictionary = new Dictionary<string, string>();
                foreach (var key in keys)
                    dictionary.Add(key, "key=[" + key + "] index=[" + i + "] rand=[" + RandomString(10) + "]");
                testDictionaryList.Add(dictionary);
            }
            entry.AddValue("application/x-forms9patchdemo-dictionaryList", testDictionaryList);


            // anything more complex than the ClipboardEntry.ValidItemType() types should be serialized (string or byte[]) and stored that way.
            entry.AddValue("application/x-forms9patchdemo-datetime-string", DateTime.Now.ToLocalTime().ToString());
            t = stopWatch.ElapsedMilliseconds;
            System.Diagnostics.Debug.WriteLine("t=[" + t + "] delta=[" + (t - lastT) + "]");
            lastT = t;


            Clipboard.Entry = entry;
            t = stopWatch.ElapsedMilliseconds;
            System.Diagnostics.Debug.WriteLine("t=[" + t + "] delta=[" + (t - lastT) + "]");
            lastT = t;

            bool success = true;
            var resultByteArray = (byte[])Clipboard.Entry.GetItem("application/x-forms9patchdemo-bytebuffer").Value;
            if (resultByteArray.Count() != testByteArray.Count())
                throw new Exception("byte array counts don't match");
            for (int i = 0; i < resultByteArray.Count(); i++)
                if (resultByteArray[i] != testByteArray[i])
                {
                    success = false;
                    break;
                }
            _byteArrayTest.Success = success;
            t = stopWatch.ElapsedMilliseconds;
            _byteArrayTest.Time = (t - lastT);
            lastT = t;




            success = true;
            var resultByte = Clipboard.Entry.GetItem("application/x-forms9patchdemo-byte").Value;
            if ((byte)resultByte != testByteArray[0])
                success = false;
            _byteTest.Success = success;
            t = stopWatch.ElapsedMilliseconds;
            _byteTest.Time = (t - lastT);
            lastT = t;

            success = true;
            var resultChar = (char)Clipboard.Entry.GetItem("application/x-forms9patchdemo-char").Value;
            if (resultChar != testChar)
                success = false;
            _charTest.Success = success;
            t = stopWatch.ElapsedMilliseconds;
            _charTest.Time = (t - lastT);
            lastT = t;

            success = true;
            var resultShort = (short)Clipboard.Entry.GetItem("application/x-forms9patchdemo-short").Value;
            if (resultShort != testShort)
                success = false;
            _shortTest.Success = success;
            t = stopWatch.ElapsedMilliseconds;
            _shortTest.Time = (t - lastT);
            lastT = t;

            success = true;
            var resultInt = (int)Clipboard.Entry.GetItem("application/x-forms9patchdemo-int").Value;
            if (resultInt != testInt)
                success = false;
            _intTest.Success = success;
            t = stopWatch.ElapsedMilliseconds;
            _intTest.Time = (t - lastT);
            lastT = t;

            success = true;
            var resultLong = (long)Clipboard.Entry.GetItem("application/x-forms9patchdemo-long").Value;
            if (resultLong != testLong)
                success = false;
            _longTest.Success = success;
            t = stopWatch.ElapsedMilliseconds;
            _longTest.Time = (t - lastT);
            lastT = t;

            success = true;
            var resultDouble = (double)Clipboard.Entry.GetItem("application/x-forms9patchdemo-double").Value;
            if (resultDouble != testDouble)
                success = false;
            _doubleTest.Success = success;
            t = stopWatch.ElapsedMilliseconds;
            _doubleTest.Time = (t - lastT);
            lastT = t;

            success = true;
            var resultString = (string)Clipboard.Entry.GetItem("application/x-forms9patchdemo-string").Value;
            if (resultString != testString)
                success = false;
            _stringTest.Success = success;
            t = stopWatch.ElapsedMilliseconds;
            _stringTest.Time = (t - lastT);
            lastT = t;

            success = true;
            var resultIntList = (List<int>)Clipboard.Entry.GetItem("application/x-forms9patchdemo-int-list").Value;
            if (resultIntList.Count != testIntList.Count)
                success = false;
            if (success)
                for (int i = 0; i < resultIntList.Count; i++)
                    if (resultIntList[i] != testIntList[i])
                    {
                        success = false;
                        break;
                    }
            _intListTest.Success = success;
            t = stopWatch.ElapsedMilliseconds;
            _intListTest.Time = (t - lastT);
            lastT = t;

            success = true;
            var resulDoubleList = (List<double>)Clipboard.Entry.GetItem("application/x-forms9patchdemo-double-list").Value;
            if (resulDoubleList.Count != testDoubleList.Count)
                success = false;
            if (success)
                for (int i = 0; i < resulDoubleList.Count; i++)
                    if (resulDoubleList[i] != testDoubleList[i])
                    {
                        success = false;
                        break;
                    }
            _doubleListTest.Success = success;
            t = stopWatch.ElapsedMilliseconds;
            _doubleListTest.Time = (t - lastT);
            lastT = t;

            success = true;
            var resultStringList = (List<string>)Clipboard.Entry.GetItem("application/x-forms9patchdemo-string-list").Value;
            if (resultStringList.Count != testStringList.Count)
                success = false;
            if (success)
                for (int i = 0; i < resultIntList.Count; i++)
                    if (resultStringList[i] != testStringList[i])
                    {
                        success = false;
                        break;
                    }
            _stringListTest.Success = success;
            t = stopWatch.ElapsedMilliseconds;
            _stringListTest.Time = (t - lastT);
            lastT = t;

            success = true;
            var resultDictionary = (Dictionary<string, double>)Clipboard.Entry.GetItem("application/x-forms9patchdemo-dictionary").Value;
            if (resultDictionary.Keys.Count != testDictionary.Keys.Count)
                success = false;
            if (success)
                foreach (var key in testDictionary.Keys)
                {
                    if (!resultDictionary.Keys.Contains(key))
                    {
                        success = false;
                        break;
                    }
                    if (resultDictionary[key] != testDictionary[key])
                    {
                        success = false;
                        break;
                    }
                }
            _dictionaryTest.Success = success;
            t = stopWatch.ElapsedMilliseconds;
            _dictionaryTest.Time = (t - lastT);
            System.Diagnostics.Debug.WriteLine("t=[" + t + "] delta=[" + (t - lastT) + "]");
            lastT = t;

            success = true;
            var resultDictionaryList = (List<Dictionary<string, string>>)Clipboard.Entry.GetItem("application/x-forms9patchdemo-dictionaryList").Value;
            if (resultDictionaryList.Count != testDictionaryList.Count)
                success = false;
            if (success)
                for (int i = 0; i < testDictionaryList.Count; i++)
                {
                    var tDictionary = testDictionaryList[i];
                    var rDictionary = resultDictionaryList[i];
                    if (tDictionary.Count != rDictionary.Count)
                        success = false;
                    if (success)
                    {
                        var tKeys = tDictionary.Keys;
                        foreach (var key in tKeys)
                        {
                            if (!rDictionary.Keys.Contains(key))
                            {
                                success = false;
                                break;
                            }
                            if (rDictionary[key] != tDictionary[key])
                            {
                                success = false;
                                break;

                            }
                        }
                    }
                }
            _dictionaryListTest.Success = success;
            t = stopWatch.ElapsedMilliseconds;
            _dictionaryListTest.Time = (t - lastT);
            System.Diagnostics.Debug.WriteLine("t=[" + t + "] delta=[" + (t - lastT) + "]");
            lastT = t;


            stopWatch.Stop();
            _elapsedTimeLabel.Text = "Elapsed time: " + stopWatch.ElapsedMilliseconds + "ms";
            return true;
        }

        static string RandomString(int length)
        {
            const string chars = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~¡¢£¤¥¦§¨©ª«⅓⅔⓪①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_rand.Next(s.Length)]).ToArray());
        }

        class StatusLabel : Xamarin.Forms.StackLayout
        {
            public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(StatusLabel), default(string));
            public string Text
            {
                get { return (string)GetValue(TextProperty); }
                set { SetValue(TextProperty, value); }
            }

            public static readonly BindableProperty SuccessProperty = BindableProperty.Create("Success", typeof(bool), typeof(StatusLabel), default(bool));
            public bool Success
            {
                get { return (bool)GetValue(SuccessProperty); }
                set { SetValue(SuccessProperty, value); }
            }
            public static readonly BindableProperty TimeProperty = BindableProperty.Create("Time", typeof(long), typeof(StatusLabel), default(long));
            public long Time
            {
                get { return (long)GetValue(TimeProperty); }
                set { SetValue(TimeProperty, value); }
            }


            Xamarin.Forms.Label _textLabel = new Xamarin.Forms.Label();
            Xamarin.Forms.Label _statusLabel = new Xamarin.Forms.Label { Text = "☐" };
            Xamarin.Forms.Label _timeLabel = new Xamarin.Forms.Label { HorizontalOptions = LayoutOptions.FillAndExpand, HorizontalTextAlignment = TextAlignment.End };

            public StatusLabel(string text)
            {
                _textLabel.Text = text;
                Orientation = StackOrientation.Horizontal;
                Children.Add(_statusLabel);
                Children.Add(_textLabel);
                Children.Add(_timeLabel);
            }

            protected override void OnPropertyChanged(string propertyName = null)
            {
                base.OnPropertyChanged(propertyName);
                if (propertyName == TextProperty.PropertyName)
                    _textLabel.Text = Text;
                else if (propertyName == SuccessProperty.PropertyName)
                {
                    _statusLabel.Text = Success ? "☑" : "☒";
                    _statusLabel.TextColor = Success ? Color.DarkGreen : Color.Red;
                }
                else if (propertyName == TimeProperty.PropertyName)
                    _timeLabel.Text = Time.ToString() + "ms";
            }
        }
    }
}
