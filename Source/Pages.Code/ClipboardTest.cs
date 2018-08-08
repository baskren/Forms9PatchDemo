using System;

using Xamarin.Forms;
using P42.Utils;
using System.Linq;
using System.Collections.Generic;
//using Forms9Patch;
using System.Reflection;
using System.Diagnostics;
using System.IO;
//using Forms9Patch;

namespace Forms9PatchDemo
{
    public class ClipboardTest : Xamarin.Forms.ContentPage
    {
        #region Fields
        static int seed = 3452;
        readonly static Random _rand = new Random(seed);
        #endregion


        #region Tests
        TestElement _byteTest = new TestElement("byte test ", (entry) =>
        {
            var testByteArray = new byte[200];
            _rand.NextBytes(testByteArray);
            entry.AddValue("application/x-forms9patchdemo-byte", testByteArray[0]);
            return testByteArray[0];
        }, (object obj) =>
        {
            var resultMimeItem = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<byte>(Forms9Patch.Clipboard.Entry, "application/x-forms9patchdemo-byte");
            if (resultMimeItem == null)
                return false;
            var resultByte = resultMimeItem.Value;
            return obj.Equals(resultByte);
        });
        TestElement _byteArrayTest = new TestElement("byte[] test ", (entry) =>
        {
            var testByteArray = new byte[200];
            _rand.NextBytes(testByteArray);
            entry.AddValue("application/x-forms9patchdemo-bytebuffer", testByteArray);
            return testByteArray;
        }, (object obj) =>
        {
            var resultByteArray = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<byte[]>(Forms9Patch.Clipboard.Entry, "application/x-forms9patchdemo-bytebuffer")?.Value;
            if (obj is byte[] testByteArray)
            {
                if (resultByteArray != null && resultByteArray.Count() != testByteArray.Count())
                    throw new Exception("byte array counts don't match");
                for (int i = 0; i < resultByteArray.Count(); i++)
                    if (resultByteArray[i] != testByteArray[i])
                        return false;
                return true;
            }
            return false;
        });
        TestElement _charTest = new TestElement("char test ", (entry) =>
        {
            var testChar = (char)_rand.Next(255);
            entry.AddValue("application/x-forms9patchdemo-char", testChar);
            return testChar;
        }, (object obj) =>
        {
            if (obj is char testChar)
            {
                var resultMimeItem = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<char>(Forms9Patch.Clipboard.Entry, "application/x-forms9patchdemo-char");
                if (resultMimeItem == null)
                    return false;
                return testChar == resultMimeItem.Value;
            }
            return false;
        });
        TestElement _shortTest = new TestElement("short test ", (entry) =>
        {
            var testShort = (short)_rand.Next(255);
            entry.AddValue("application/x-forms9patchdemo-short", testShort);
            return testShort;
        }, (object obj) =>
        {
            if (obj is short testShort)
            {
                var resultMimeItem = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<short>(Forms9Patch.Clipboard.Entry, "application/x-forms9patchdemo-short");
                if (resultMimeItem == null)
                    return false;
                return testShort == resultMimeItem.Value;
            }
            return false;
        });
        TestElement _intTest = new TestElement("int test ", (entry) =>
        {
            var testInt = _rand.Next();
            entry.AddValue("application/x-forms9patchdemo-int", testInt);
            return testInt;
        }, (object obj) =>
        {
            if (obj is int testInt)
            {
                var resultMimeItem = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<int>(Forms9Patch.Clipboard.Entry, "application/x-forms9patchdemo-int");
                if (resultMimeItem?.Value == null)
                    return false;
                return testInt == resultMimeItem.Value;
            }
            return false;
        });
        TestElement _longTest = new TestElement("long test ", (entry) =>
        {
            var testLong = (long)_rand.Next() + (long)int.MaxValue;
            entry.AddValue("application/x-forms9patchdemo-long", testLong);
            return testLong;
        }, (object obj) =>
        {
            if (obj is long testLong)
            {
                var resultMimeItem = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<long>(Forms9Patch.Clipboard.Entry, "application/x-forms9patchdemo-long");
                if (resultMimeItem?.Value == null)
                    return false;
                return testLong == resultMimeItem.Value;
            }
            return false;
        });
        TestElement _doubleTest = new TestElement("double test ", (entry) =>
        {
            var testDouble = _rand.NextDouble();
            entry.AddValue("application/x-forms9patchdemo-double", testDouble);
            return testDouble;
        }, (object obj) =>
        {
            if (obj is double testDouble)
            {
                var resultMimeItem = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<double>(Forms9Patch.Clipboard.Entry, "application/x-forms9patchdemo-double");
                if (resultMimeItem?.Value == null)
                    return false;
                return Math.Abs(testDouble - resultMimeItem.Value) < 0.00001;
            }
            return false;
        });
        TestElement _stringTest = new TestElement("string test ", (entry) =>
        {
            var testString = "This is application/x-forms9patchdemo-string: ⅓ ⅔ ⓪ ① ② ③ ④ ⑤ ⑥ ⑦ ⑧ ⑨ ⑩ ⑪ ⑫ ⑬ ⑭ ⑮ ⑯ ⑰ ⑱ ⑲ ⑳  🅰 🅱 🅲 🅳 🅴 🅵 🅶 🅷 🅸 🅹 🅺 🅻 🅼 🅽 🅾 🅿 🆀 🆁 🆂 🆃 🆄 🆅 🆆 🆇 🆈 🆉 🙃 😐 😑 🤔 🙄 😮 😔 😖 😕";
            entry.AddValue("application/x-forms9patchdemo-string", testString);
            entry.AddValue("text/plain", testString);
            return testString;
        }, (object obj) =>
        {
            if (obj is string testString)
            {
                var resultString = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<string>(Forms9Patch.Clipboard.Entry, "application/x-forms9patchdemo-string")?.Value as string;
                if (testString != resultString)
                    return false;
                resultString = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<string>(Forms9Patch.Clipboard.Entry, "text/plain")?.Value as string;
                return testString == resultString;
            }
            return false;
        });
        TestElement _intListTest = new TestElement("List<int> test ", (entry) =>
        {
            var testIntList = new List<int>();
            for (int i = 0; i < 20; i++)
                testIntList.Add(i);
            entry.AddValue("application/x-forms9patchdemo-int-list", testIntList);
            return testIntList;
        }, (object obj) =>
        {
            if (obj is List<int> testIntList)
            {
                var resultIntList = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<List<int>>(Forms9Patch.Clipboard.Entry, "application/x-forms9patchdemo-int-list")?.Value as List<int>;
                if (resultIntList == null || resultIntList.Count != testIntList.Count)
                    return false;
                for (int i = 0; i < resultIntList.Count; i++)
                    if (resultIntList[i] != testIntList[i])
                        return false;
                return true;
            }
            return false;
        });
        TestElement _doubleListTest = new TestElement("List<double> test ", (entry) =>
        {
            var testDoubleList = new List<double>();
            for (int i = 0; i < 20; i++)
                testDoubleList.Add(i + i / 10.0);
            entry.AddValue("application/x-forms9patchdemo-double-list", testDoubleList);
            return testDoubleList;
        }, (object obj) =>
        {
            if (obj is List<double> testDoubleList)
            {
                var resulDoubleList = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<List<double>>(Forms9Patch.Clipboard.Entry, "application/x-forms9patchdemo-double-list")?.Value as List<double>;
                if (resulDoubleList == null || resulDoubleList.Count != testDoubleList.Count)
                    return false;
                for (int i = 0; i < resulDoubleList.Count; i++)
                    if (Math.Abs(resulDoubleList[i] - testDoubleList[i]) > 0.00001)
                        return false;
                return true;
            }
            return false;
        });
        TestElement _stringListTest = new TestElement("List<string> test ", (entry) =>
        {
            var testStringList = new List<string>();
            for (int i = 0; i < 20; i++)
                testStringList.Add(RandomString(10));
            entry.AddValue("application/x-forms9patchdemo-string-list", testStringList);
            return testStringList;
        }, (object obj) =>
        {
            if (obj is List<string> testStringList)
            {
                var resultStringList = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<List<string>>(Forms9Patch.Clipboard.Entry, "application/x-forms9patchdemo-string-list")?.Value as List<string>;
                if (resultStringList == null || resultStringList.Count != testStringList.Count)
                    return false;
                for (int i = 0; i < resultStringList.Count; i++)
                    if (resultStringList[i] != testStringList[i])
                        return false;
                return true;
            }
            return false;
        });
        TestElement _dictionaryTest = new TestElement("Dictionary<string,double> test ", (entry) =>
        {
            var testDictionary = new Dictionary<string, double>();
            for (int i = 0; i < 20; i++)
                testDictionary.Add(RandomString(10), i + i / 10.0);
            entry.AddValue("application/x-forms9patchdemo-dictionary", testDictionary);

            return testDictionary;
        }, (object obj) =>
        {
            if (obj is Dictionary<string, double> testDictionary)
            {
                var resultDictionary = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<Dictionary<string, double>>(Forms9Patch.Clipboard.Entry, "application/x-forms9patchdemo-dictionary")?.Value as Dictionary<string, double>;
                if (resultDictionary == null || resultDictionary.Keys.Count != testDictionary.Keys.Count)
                    return false;
                foreach (var key in testDictionary.Keys)
                {
                    if (!resultDictionary.Keys.Contains(key))
                        return false;
                    if (Math.Abs(resultDictionary[key] - testDictionary[key]) > 0.0001)
                        return false;
                }
                return true;
            }
            return false;
        });
        TestElement _dictionaryListTest = new TestElement("List<Dictionary<string,double>> test ", (entry) =>
        {
            var keys = new List<string>();
            for (int i = 0; i < 20; i++)
                keys.Add(RandomString(10));
            var testDictionaryList = new List<Dictionary<string, double>>();
            for (int i = 0; i < 20; i++)
            {
                var dictionary = new Dictionary<string, double>();
                foreach (var key in keys)
                    dictionary.Add(key, _rand.NextDouble());
                testDictionaryList.Add(dictionary);
            }
            entry.AddValue("application/x-forms9patchdemo-dictionaryList", testDictionaryList);
            return testDictionaryList;
        }, (object obj) =>
        {
            if (obj is List<Dictionary<string, double>> testDictionaryList)
            {
                var resultDictionaryList = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<List<Dictionary<string, double>>>(Forms9Patch.Clipboard.Entry, "application/x-forms9patchdemo-dictionaryList")?.Value as List<Dictionary<string, double>>;
                if (resultDictionaryList == null || resultDictionaryList.Count != testDictionaryList.Count)
                    return false;
                for (int i = 0; i < testDictionaryList.Count; i++)
                {
                    var tDictionary = testDictionaryList[i];
                    var rDictionary = resultDictionaryList[i];
                    if (tDictionary.Count != rDictionary.Count)
                        return false;
                    var tKeys = tDictionary.Keys;
                    foreach (var key in tKeys)
                    {
                        if (!rDictionary.Keys.Contains(key))
                            return false;
                        if (rDictionary[key] != tDictionary[key])
                            return false;
                    }
                }
                return true;
            }
            return false;
        });
        TestElement _dateTimeTest = new TestElement("DateTime as JSON", (entry) =>
        {
            // anything more complex than the ClipboardEntry.ValidItemType() types should be serialized (string, byte[], or uri) and stored that way. 
            var dateTime = DateTime.Now;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dateTime);
            entry.AddValue("application/json", json);
            return json;
        }, (obj) =>
        {
            if (obj is string testJson)
            {
                var dateTimeResultJson = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<string>(Forms9Patch.Clipboard.Entry, "application/json")?.Value as string;
                var resultDateTime = Newtonsoft.Json.JsonConvert.DeserializeObject<DateTime>(dateTimeResultJson);
                return testJson == dateTimeResultJson;
            }
            return false;
        });

        TestElement _jpegByteArrayTest = new TestElement("jpeg from byte[] test", (entry) =>
        {
            // anything more complex than the ClipboardEntry.ValidItemType() types should be serialized (string, byte[], or uri) and stored that way. 
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "balloons1.jpg");
            ExtractEmbeddedResourceToPath(typeof(ClipboardTest).Assembly, "Forms9PatchDemo.Resources.balloons1.jpg", path);
            if (!File.Exists(path))
                throw new Exception("EmbeddedResource (balloons.jpg) was not extracted to file");
            var testByteArray = File.ReadAllBytes(path);
            _testImage.Source = Xamarin.Forms.ImageSource.FromStream(() => new MemoryStream(testByteArray));
            entry.AddValue("image/jpeg", testByteArray);
            return testByteArray;
        }, (object obj) =>
        {
            if (obj is byte[] testByteArray)
            {
                var mimeItem = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<byte[]>(Forms9Patch.Clipboard.Entry, "image/jpeg");
                var mimeResult = mimeItem?.Value;
                _resultImage.Source = Xamarin.Forms.ImageSource.FromStream(() => new MemoryStream(mimeResult));
                if (testByteArray.Length == mimeResult.Length)
                    return NewMemCmp(testByteArray, mimeResult, testByteArray.Length);
                return false;
            }
            return false;
        });

        TestElement _jpegFilePathTest = new TestElement("jpeg from file path test", (entry) =>
        {
            // anything more complex than the ClipboardEntry.ValidItemType() types should be serialized (string, byte[], or uri) and stored that way. 
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "balloons2.jpg");
            ExtractEmbeddedResourceToPath(typeof(ClipboardTest).Assembly, "Forms9PatchDemo.Resources.balloons2.jpg", path);
            if (!File.Exists(path))
                throw new Exception("EmbeddedResource (balloons.jpg) was not extracted to file");
            entry.AddValue("image/jpeg", path);
            _testImage.Source = Xamarin.Forms.ImageSource.FromFile(path);
            return path;
        }, (object obj) =>
        {
            if (obj is string testPath)
            {
                // looks like iOS convertes NSUrl to NSData
                var mimeItem = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<string>(Forms9Patch.Clipboard.Entry, "image/jpeg");
                var resultPath = mimeItem?.Value;
                _resultImage.Source = Xamarin.Forms.ImageSource.FromFile(resultPath);
                return testPath == resultPath;
            }
            return false;
        });


        TestElement _pngTest = new TestElement("png byte[] test", (entry) =>
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "236-baby.png");
            ExtractEmbeddedResourceToPath(typeof(ClipboardTest).Assembly, "Forms9PatchDemo.Resources.236-baby.png", path);
            if (!File.Exists(path))
                throw new Exception("EmbeddedResource (236-baby.png) was not extracted to file");
            var result = Forms9Patch.IClipboardEntryExtensions.AddBytesFromFile(entry, "image/png", path);
            _testImage.Source = Xamarin.Forms.ImageSource.FromStream(() => new MemoryStream(result));
            return result;
        }, (object obj) =>
        {
            if (obj is byte[] testByteArray)
            {
                var mimeItem = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<byte[]>(Forms9Patch.Clipboard.Entry, "image/png");
                var mimeResult = mimeItem?.Value;
                _resultImage.Source = Xamarin.Forms.ImageSource.FromStream(() => new MemoryStream(mimeResult));
                if (testByteArray.Length == mimeResult.Length)
                    return NewMemCmp(testByteArray, mimeResult, testByteArray.Length);
                return false;
            }
            return false;
        });

        TestElement _pdfTest = new TestElement("pdf byte[] test", (entry) =>
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "ProjectProposal.pdf");
            ExtractEmbeddedResourceToPath(typeof(ClipboardTest).Assembly, "Forms9PatchDemo.Resources.ProjectProposal.pdf", path);
            if (!File.Exists(path))
                throw new Exception("EmbeddedResource (ProjectProposal.pdf) was not extracted to file");
            return Forms9Patch.IClipboardEntryExtensions.AddBytesFromFile(entry, "application/pdf", path);
        }, (object obj) =>
        {
            if (obj is byte[] testByteArray)
            {
                var mimeItem = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<byte[]>(Forms9Patch.Clipboard.Entry, "application/pdf");
                var resultByteArray = mimeItem?.Value;
                if (testByteArray.Length == resultByteArray.Length)
                    return NewMemCmp(testByteArray, resultByteArray, testByteArray.Length);
                return false;
            }
            return false;
        });

        TestElement _jpegHttpUrlTest = new TestElement("jpeg http url test", (entry) =>
        {
            var uri = new Uri("https://i.redditmedia.com/npNromwDHMXlxFMa0CAZqw0MMSKFj-aHx5rvgQNPXyA.jpg?fit=crop&crop=faces%2Centropy&arh=2&w=640&s=04fe226f00868a3182265a9af861608e");
            entry.AddValue("image/jpeg", uri.AbsoluteUri);
            _testImage.Source = Xamarin.Forms.ImageSource.FromUri(uri);
            return uri.AbsoluteUri;
        }, (object obj) =>
        {
            if (obj is string testUri)
            {
                //var resultUri = Forms9Patch.Clipboard.Entry.Uri;
                var result = Forms9Patch.IClipboardEntryExtensions.GetFirstMimeItem<string>(Forms9Patch.Clipboard.Entry, "image/jpeg");
                if (result?.Value == null)
                    return false;
                var resultUri = new Uri(result.Value);
                _resultImage.Source = Xamarin.Forms.ImageSource.FromUri(resultUri);
                return testUri == result.Value;
            }
            return false;
        });

        TestElement _pdfFileTest = new TestElement("pdf file test", (entry) =>
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "ProjectProposal.pdf");
            ExtractEmbeddedResourceToPath(typeof(ClipboardTest).Assembly, "Forms9PatchDemo.Resources.ProjectProposal.pdf", path);
            if (!File.Exists(path))
                throw new Exception("EmbeddedResource (ProjectProposal.pdf) was not extracted to file");
            var url = "file://" + path;
            entry.AddValue("image/jpeg", path);
            _testImage.Source = Xamarin.Forms.ImageSource.FromFile(path);
            return url;
        }, (object obj) =>
        {
            if (obj is string testUrlString)
            {
                /*
                var mimeItem = Forms9Patch.Clipboard.Entry.GetItem<byte[]>("application/pdf");
                var resultByteArray = mimeItem?.Value;
                if (testByteArray.Length == resultByteArray.Length)
                    return NewMemCmp(testByteArray, resultByteArray, testByteArray.Length);
*/
                return false;
            }
            return false;
        });


        #endregion


        #region other visual elements
        Xamarin.Forms.Label _availableMimeTypesLabel = new Xamarin.Forms.Label();

        Xamarin.Forms.Label _elapsedTimeLabel = new Xamarin.Forms.Label();

        Xamarin.Forms.StackLayout _layout = new Xamarin.Forms.StackLayout
        {
            Children = { new Forms9Patch.Label("<b>Copy / Paste tests:</b>") }
        };

        Xamarin.Forms.Switch _entryCaching = new Xamarin.Forms.Switch { HorizontalOptions = LayoutOptions.End };
        //Switch _entryItemTypeCaching = new Switch { HorizontalOptions = LayoutOptions.End };
        Xamarin.Forms.Button _execute = new Xamarin.Forms.Button
        {
            Text = "run test"
        };

        Forms9Patch.Toast _clipboardChangedToast = new Forms9Patch.Toast { Title = "CLIPBOARD CHANGED", Text = "The clipboard has changed." };

        static Xamarin.Forms.Image _testImage = new Xamarin.Forms.Image
        {
            Aspect = Aspect.AspectFit,
        };

        static Xamarin.Forms.Image _resultImage = new Xamarin.Forms.Image
        {
            Aspect = Aspect.AspectFit,
        };

        Xamarin.Forms.Grid _jpegComparisonGrid = new Xamarin.Forms.Grid
        {
            ColumnDefinitions =
            {
                new ColumnDefinition{ Width = GridLength.Star },
                new ColumnDefinition{ Width = GridLength.Star },
            },
        };


        #endregion


        public ClipboardTest()
        {
            Padding = new Thickness(20, Device.RuntimePlatform == Device.iOS ? 40 : 20, 20, 0);

            _entryCaching.IsToggled = Forms9Patch.Clipboard.EntryCaching;

            _entryCaching.Toggled += (sender, e) => Forms9Patch.Clipboard.EntryCaching = _entryCaching.IsToggled;

            _jpegComparisonGrid.Children.Add(_testImage);
            _jpegComparisonGrid.Children.Add(_resultImage, 1, 0);


            _layout.Children.Add(new Xamarin.Forms.Label { Text = "Available Mime Types: " });
            _layout.Children.Add(_availableMimeTypesLabel);
            _layout.Children.Add(new BoxView { Color = Color.Black, HeightRequest = 1 });
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
            _layout.Children.Add(_dateTimeTest);
            _layout.Children.Add(_pdfTest);

            _layout.Children.Add(new BoxView { Color = Color.Blue, HeightRequest = 5 });
            _layout.Children.Add(new Label { Text = "Must visually check images because results will not be the same, byte for byte" });
            _layout.Children.Add(new BoxView { Color = Color.Blue, HeightRequest = 5 });

            _layout.Children.Add(_pngTest);
            _layout.Children.Add(_jpegByteArrayTest);
            _layout.Children.Add(_jpegFilePathTest);
            _layout.Children.Add(_jpegHttpUrlTest);
            _layout.Children.Add(_jpegComparisonGrid);
            _layout.Children.Add(new BoxView { Color = Color.Blue, HeightRequest = 5 });
            _layout.Children.Add(new Forms9Patch.Label("Entry caching:"));
            _layout.Children.Add(_entryCaching);
            _layout.Children.Add(_execute);
            _layout.Children.Add(new BoxView { Color = Color.Blue, HeightRequest = 5 });
            _layout.Children.Add(_elapsedTimeLabel);

            Content = new ScrollView
            {
                Content = _layout
            };

            _execute.Clicked += (sender, e) => CopyPaste();

            System.Diagnostics.Debug.WriteLine("ClipboardTest Constructor 1");
            UpdateAvailableMimeTypesLabel();
            System.Diagnostics.Debug.WriteLine("ClipboardTest Constructor 2");

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Keep in mind, event handlers can be zombies.  Think about proper disposal (or squelching) if you want to be sure it doesn't appear after you leave the page/view where you instantiated it.
            Forms9Patch.Clipboard.ContentChanged += Clipboard_ContentChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Forms9Patch.Clipboard.ContentChanged -= Clipboard_ContentChanged;
        }

        void Clipboard_ContentChanged(object sender, EventArgs e)
        {
            _clipboardChangedToast.IsVisible = true;
            UpdateAvailableMimeTypesLabel();
        }

        void UpdateAvailableMimeTypesLabel()
        {
            var items = Forms9Patch.Clipboard.Entry?.Items;
            if (items != null && items.Count > 0)
            {
                var mimeTypes = items.Select((mimeEntry) => mimeEntry.MimeType);
                _availableMimeTypesLabel.Text = string.Join(", ", mimeTypes);
            }
            else
                _availableMimeTypesLabel.Text = null;
        }


        bool CopyPaste()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var entry = new Forms9Patch.ClipboardEntry();
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 1 elapsed: " + stopwatch.ElapsedMilliseconds);


            var testByte = (byte)_byteTest.CopyAction.Invoke(entry);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 2.01 elapsed: " + stopwatch.ElapsedMilliseconds);
            var testByteArray = (byte[])_byteArrayTest.CopyAction.Invoke(entry);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 2.02 elapsed: " + stopwatch.ElapsedMilliseconds);
            var testChar = (char)_charTest.CopyAction.Invoke(entry);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 2.03 elapsed: " + stopwatch.ElapsedMilliseconds);
            var testShort = (short)_shortTest.CopyAction.Invoke(entry);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 2.04 elapsed: " + stopwatch.ElapsedMilliseconds);
            var testInt = (int)_intTest.CopyAction.Invoke(entry);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 2.05 elapsed: " + stopwatch.ElapsedMilliseconds);
            var testLong = (long)_longTest.CopyAction.Invoke(entry);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 2.06 elapsed: " + stopwatch.ElapsedMilliseconds);
            var testDouble = (double)_doubleTest.CopyAction.Invoke(entry);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 2.07 elapsed: " + stopwatch.ElapsedMilliseconds);
            var testString = (string)_stringTest.CopyAction.Invoke(entry);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 2.08 elapsed: " + stopwatch.ElapsedMilliseconds);
            var testIntList = (List<int>)_intListTest.CopyAction.Invoke(entry);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 2.09 elapsed: " + stopwatch.ElapsedMilliseconds);
            var testDoubleList = (List<double>)_doubleListTest.CopyAction.Invoke(entry);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 2.10 elapsed: " + stopwatch.ElapsedMilliseconds);
            var testStringList = (List<string>)_stringListTest.CopyAction.Invoke(entry);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 2.11 elapsed: " + stopwatch.ElapsedMilliseconds);
            var testDictionary = (Dictionary<string, double>)_dictionaryTest.CopyAction.Invoke(entry);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 2.12 elapsed: " + stopwatch.ElapsedMilliseconds);
            var testDictionaryList = (List<Dictionary<string, double>>)_dictionaryListTest.CopyAction.Invoke(entry);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 2.13 elapsed: " + stopwatch.ElapsedMilliseconds);
            var testDateTimeJson = (string)_dateTimeTest.CopyAction.Invoke(entry);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 2.14 elapsed: " + stopwatch.ElapsedMilliseconds);
            var testPdf = (byte[])_pdfTest.CopyAction.Invoke(entry);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 2.15 elapsed: " + stopwatch.ElapsedMilliseconds);
            var testJpegByteArray = (byte[])_jpegByteArrayTest.CopyAction.Invoke(entry);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 2.16 elapsed: " + stopwatch.ElapsedMilliseconds);
            var testPngByteArray = (byte[])_pngTest.CopyAction.Invoke(entry);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 2.17 elapsed: " + stopwatch.ElapsedMilliseconds);

            Forms9Patch.Clipboard.Entry = entry;
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 3 elapsed: " + stopwatch.ElapsedMilliseconds);

            _byteTest.Success = _byteTest.PasteFunction(testByte);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 4.01 elapsed: " + stopwatch.ElapsedMilliseconds);
            _byteArrayTest.Success = _byteArrayTest.PasteFunction(testByteArray);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 4.02 elapsed: " + stopwatch.ElapsedMilliseconds);
            _charTest.Success = _charTest.PasteFunction(testChar);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 4.03 elapsed: " + stopwatch.ElapsedMilliseconds);
            _shortTest.Success = _shortTest.PasteFunction(testShort);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 4.04 elapsed: " + stopwatch.ElapsedMilliseconds);
            _intTest.Success = _intTest.PasteFunction(testInt);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 4.05 elapsed: " + stopwatch.ElapsedMilliseconds);
            _longTest.Success = _longTest.PasteFunction(testLong);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 4.06 elapsed: " + stopwatch.ElapsedMilliseconds);
            _doubleTest.Success = _doubleTest.PasteFunction(testDouble);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 4.07 elapsed: " + stopwatch.ElapsedMilliseconds);
            _stringTest.Success = _stringTest.PasteFunction(testString);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 4.08 elapsed: " + stopwatch.ElapsedMilliseconds);
            _intListTest.Success = _intListTest.PasteFunction(testIntList);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 4.09 elapsed: " + stopwatch.ElapsedMilliseconds);
            _doubleListTest.Success = _doubleListTest.PasteFunction(testDoubleList);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 4.10 elapsed: " + stopwatch.ElapsedMilliseconds);
            _stringListTest.Success = _stringListTest.PasteFunction(testStringList);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 4.11 elapsed: " + stopwatch.ElapsedMilliseconds);
            _dictionaryTest.Success = _dictionaryTest.PasteFunction(testDictionary);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 4.12 elapsed: " + stopwatch.ElapsedMilliseconds);
            _dictionaryListTest.Success = _dictionaryListTest.PasteFunction(testDictionaryList);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 4.13 elapsed: " + stopwatch.ElapsedMilliseconds);
            _dateTimeTest.Success = _dateTimeTest.PasteFunction(testDateTimeJson);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 4.14 elapsed: " + stopwatch.ElapsedMilliseconds);
            _pdfTest.Success = _pdfTest.PasteFunction(testPdf);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 4.15 elapsed: " + stopwatch.ElapsedMilliseconds);
            _jpegByteArrayTest.Success = _jpegByteArrayTest.PasteFunction(testJpegByteArray);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 4.16 elapsed: " + stopwatch.ElapsedMilliseconds);
            _pngTest.Success = _pngTest.PasteFunction(testPngByteArray);
            System.Diagnostics.Debug.WriteLine("\t CopyPaste 4.17 elapsed: " + stopwatch.ElapsedMilliseconds);

            stopwatch.Stop();
            _elapsedTimeLabel.Text = "Elapsed time: " + stopwatch.ElapsedMilliseconds + "ms";
            return true;
        }

        static string RandomString(int length)
        {
            const string chars = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~¡¢£¤¥¦§¨©ª«⅓⅔⓪①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_rand.Next(s.Length)]).ToArray());
        }

        static void ExtractEmbeddedResourceToPath(Assembly assembly, String embeddedResourceId, String path)
        {
            Stream resFilestream = assembly.GetManifestResourceStream(embeddedResourceId);
            if (resFilestream != null)
            {
                System.Diagnostics.Debug.WriteLine("embedded resource length: " + resFilestream.Length);
                using (BinaryReader br = new BinaryReader(resFilestream))
                {
                    if (br != null)
                    {
                        using (FileStream fs = new FileStream(path, FileMode.Create))
                        {
                            if (fs != null)
                            {
                                using (BinaryWriter bw = new BinaryWriter(fs))
                                {
                                    if (bw != null)
                                    {
                                        byte[] ba = new byte[resFilestream.Length];
                                        resFilestream.Read(ba, 0, ba.Length);
                                        bw.Write(ba);
                                        var fileInfo = new System.IO.FileInfo(path);
                                        System.Diagnostics.Debug.WriteLine("output length: " + fileInfo.Length);
                                        System.Diagnostics.Debug.WriteLine("output length: " + fs.Length);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        static byte[] ByteArrayFromFile(String path)
        {
            using (FileStream filestream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                if (filestream != null)
                {
                    System.Diagnostics.Debug.WriteLine("embedded resource length: " + filestream.Length);
                    using (BinaryReader br = new BinaryReader(filestream))
                    {
                        if (br != null)
                        {
                            //using (FileStream fs = new FileStream(path, FileMode.Create))
                            using (MemoryStream ms = new MemoryStream((int)filestream.Length))
                            {
                                if (ms != null)
                                {
                                    using (BinaryWriter bw = new BinaryWriter(ms))
                                    {
                                        if (bw != null)
                                        {
                                            byte[] ba = new byte[filestream.Length];
                                            filestream.Read(ba, 0, ba.Length);
                                            bw.Write(ba);
                                            var fileInfo = new System.IO.FileInfo(path);
                                            System.Diagnostics.Debug.WriteLine("output length: " + fileInfo.Length);
                                            System.Diagnostics.Debug.WriteLine("output length: " + ms.Length);
                                            return ms.ToArray();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        public static unsafe bool NewMemCmp(byte* b0, byte* b1, int length)
        {
            byte* lastAddr = b0 + length;
            byte* lastAddrMinus32 = lastAddr - 32;
            while (b0 < lastAddrMinus32) // unroll the loop so that we are comparing 32 bytes at a time.
            {
                if (*(ulong*)b0 != *(ulong*)b1) return false;
                if (*(ulong*)(b0 + 8) != *(ulong*)(b1 + 8)) return false;
                if (*(ulong*)(b0 + 16) != *(ulong*)(b1 + 16)) return false;
                if (*(ulong*)(b0 + 24) != *(ulong*)(b1 + 24)) return false;
                b0 += 32;
                b1 += 32;
            }
            while (b0 < lastAddr)
            {
                if (*b0 != *b1) return false;
                b0++;
                b1++;
            }
            return true;
        }

        public static unsafe bool NewMemCmp(byte[] arr0, byte[] arr1, int length)
        {
            fixed (byte* b0 = arr0, b1 = arr1)
            {
                return b0 == b1 || NewMemCmp(b0, b1, length);
            }
        }

        class TestElement : Xamarin.Forms.StackLayout
        {
            public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(TestElement), default(string));
            public string Text
            {
                get { return (string)GetValue(TextProperty); }
                set { SetValue(TextProperty, value); }
            }

            public static readonly BindableProperty SuccessProperty = BindableProperty.Create("Success", typeof(bool), typeof(TestElement), default(bool));
            public bool Success
            {
                get { return (bool)GetValue(SuccessProperty); }
                set { SetValue(SuccessProperty, value); }
            }
            public static readonly BindableProperty TimeProperty = BindableProperty.Create("Time", typeof(long), typeof(TestElement), default(long));
            public long Time
            {
                get { return (long)GetValue(TimeProperty); }
                set { SetValue(TimeProperty, value); }
            }

            public Func<Forms9Patch.ClipboardEntry, object> CopyAction { get; private set; }

            public Func<object, bool> PasteFunction { get; private set; }

            readonly Xamarin.Forms.Button _testButton = new Xamarin.Forms.Button { Text = " Test ", BorderWidth = 1, BorderColor = Color.Blue, HorizontalOptions = LayoutOptions.Start };
            readonly Xamarin.Forms.Label _textLabel = new Xamarin.Forms.Label();
            readonly Xamarin.Forms.Label _statusLabel = new Xamarin.Forms.Label { Text = "☐" };
            readonly Xamarin.Forms.Label _timeLabel = new Xamarin.Forms.Label { HorizontalOptions = LayoutOptions.FillAndExpand, HorizontalTextAlignment = TextAlignment.End };

            public TestElement(string text, Func<Forms9Patch.ClipboardEntry, object> copyAction = null, Func<object, bool> pasteFunction = null)
            {
                _textLabel.Text = text;
                CopyAction = copyAction;
                PasteFunction = pasteFunction;
                Orientation = StackOrientation.Horizontal;
                if (CopyAction != null && PasteFunction != null)
                {
                    Children.Add(_testButton);
                    _testButton.Clicked += (s, e) =>
                    {
                        var stopWatch = new Stopwatch();
                        stopWatch.Start();
                        var entry = new Forms9Patch.ClipboardEntry();
                        System.Diagnostics.Debug.WriteLine("\t TestElement 1 elapsed: " + stopWatch.ElapsedMilliseconds);
                        var obj = CopyAction.Invoke(entry);
                        System.Diagnostics.Debug.WriteLine("\t TestElement 2 elapsed: " + stopWatch.ElapsedMilliseconds);
                        Forms9Patch.Clipboard.Entry = entry;
                        System.Diagnostics.Debug.WriteLine("\t TestElement 3 elapsed: " + stopWatch.ElapsedMilliseconds);
                        Success = PasteFunction.Invoke(obj);
                        System.Diagnostics.Debug.WriteLine("\t TestElement 4 elapsed: " + stopWatch.ElapsedMilliseconds);
                        stopWatch.Stop();
                        Time = stopWatch.ElapsedMilliseconds;
                    };
                }
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
