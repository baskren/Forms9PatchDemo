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
            var resultMimeItem = Forms9Patch.Clipboard.Entry.GetItem<byte>("application/x-forms9patchdemo-byte");
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
            var resultByteArray = Forms9Patch.Clipboard.Entry.GetItem<byte[]>("application/x-forms9patchdemo-bytebuffer").Value;
            if (obj is byte[] testByteArray)
            {
                if (resultByteArray.Count() != testByteArray.Count())
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
                var resultChar = Forms9Patch.Clipboard.Entry.GetItem<char>("application/x-forms9patchdemo-char").Value;
                return resultChar == testChar;
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
                var resultShort = Forms9Patch.Clipboard.Entry.GetItem<short>("application/x-forms9patchdemo-short").Value;
                return resultShort == testShort;
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
                var resultInt = Forms9Patch.Clipboard.Entry.GetItem<int>("application/x-forms9patchdemo-int").Value;
                return testInt == resultInt;
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
                var resultLong = Forms9Patch.Clipboard.Entry.GetItem<long>("application/x-forms9patchdemo-long").Value;
                return resultLong == testLong;
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
                var resultDouble = Forms9Patch.Clipboard.Entry.GetItem<double>("application/x-forms9patchdemo-double").Value;
                return Math.Abs(testDouble - resultDouble) < 0.00001;
            }
            return false;
        });
        TestElement _stringTest = new TestElement("string test ", (entry) =>
        {
            var testString = "This is application/x-forms9patchdemo-string: ⅓ ⅔ ⓪ ① ② ③ ④ ⑤ ⑥ ⑦ ⑧ ⑨ ⑩ ⑪ ⑫ ⑬ ⑭ ⑮ ⑯ ⑰ ⑱ ⑲ ⑳  🅰 🅱 🅲 🅳 🅴 🅵 🅶 🅷 🅸 🅹 🅺 🅻 🅼 🅽 🅾 🅿 🆀 🆁 🆂 🆃 🆄 🆅 🆆 🆇 🆈 🆉 🙃 😐 😑 🤔 🙄 😮 😔 😖 😕";
            entry.AddValue("application/x-forms9patchdemo-string", testString);
            return testString;
        }, (object obj) =>
        {
            if (obj is string testString)
            {
                var resultString = Forms9Patch.Clipboard.Entry.GetItem<string>("application/x-forms9patchdemo-string").Value;
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
                var resultIntList = Forms9Patch.Clipboard.Entry.GetItem<List<int>>("application/x-forms9patchdemo-int-list").Value;
                if (resultIntList.Count != testIntList.Count)
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
                var resulDoubleList = Forms9Patch.Clipboard.Entry.GetItem<List<double>>("application/x-forms9patchdemo-double-list").Value;
                if (resulDoubleList.Count != testDoubleList.Count)
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
                var resultStringList = Forms9Patch.Clipboard.Entry.GetItem<List<string>>("application/x-forms9patchdemo-string-list").Value;
                if (resultStringList.Count != testStringList.Count)
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
                var resultDictionary = Forms9Patch.Clipboard.Entry.GetItem<Dictionary<string, double>>("application/x-forms9patchdemo-dictionary").Value;
                if (resultDictionary.Keys.Count != testDictionary.Keys.Count)
                    return false;
                foreach (var key in testDictionary.Keys)
                {
                    if (!resultDictionary.Keys.Contains(key))
                        return false;
                    if (resultDictionary[key] != testDictionary[key])
                        return false;
                }
                return true;
            }
            return false;
        });
        TestElement _dictionaryListTest = new TestElement("List<Dictionary<string,double>> test ", (entry) =>
        {
            var testDictionary = new Dictionary<string, double>();
            for (int i = 0; i < 20; i++)
                testDictionary.Add(RandomString(10), i + i / 10.0);
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
            return testDictionaryList;
        }, (object obj) =>
        {
            if (obj is List<Dictionary<string, string>> testDictionaryList)
            {
                var entryItem = Forms9Patch.Clipboard.Entry.GetItem<List<Dictionary<string, string>>>("application/x-forms9patchdemo-dictionaryList");
                var resultDictionaryList = entryItem.Value;
                if (resultDictionaryList.Count != testDictionaryList.Count)
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
        TestElement _dateTimeTest = new TestElement("DateTime", (entry) =>
        {
            // anything more complex than the ClipboardEntry.ValidItemType() types should be serialized (string, byte[], or uri) and stored that way. 
            var dateTime = DateTime.Now;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(dateTime);
            entry.AddValue("application/x-forms9patchdemo-datetime-string", json);
            return dateTime;
        }, (obj) =>
        {
            if (obj is DateTime testDateTime)
            {
                var dateTimeResultJson = Forms9Patch.Clipboard.Entry.GetItem<string>("application/x-forms9patchdemo-datetime-string").Value;
                var resultDateTime = Newtonsoft.Json.JsonConvert.DeserializeObject<DateTime>(dateTimeResultJson);
                return testDateTime == resultDateTime;
            }
            return false;
        });

        TestElement _jpegTest = new TestElement("jpeg file test", (entry) =>
        {
            // anything more complex than the ClipboardEntry.ValidItemType() types should be serialized (string, byte[], or uri) and stored that way. 
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "balloons.jpg");
            ExtractEmbeddedResourceToPath(typeof(ClipboardTest).Assembly, "Forms9PatchDemo.Resources.balloons.jpg", path);
            if (!File.Exists(path))
                throw new Exception("EmbeddedResource (balloons.jpg) was not extracted to file");
            var result = entry.AddContentOfFile("image/jpeg", path);
            _testImage.Source = Xamarin.Forms.ImageSource.FromStream(() => new MemoryStream(result));
            return result;
        }, (object obj) =>
        {
            if (obj is byte[] testByteArray)
            {
                var mimeItem = Forms9Patch.Clipboard.Entry.GetItem<byte[]>("image/jpeg");
                var mimeResult = mimeItem?.Value;
                _resultImage.Source = Xamarin.Forms.ImageSource.FromStream(() => new MemoryStream(mimeResult));
                if (testByteArray.Length == mimeResult.Length)
                    return NewMemCmp(testByteArray, mimeResult, testByteArray.Length);
                return false;
            }
            return false;
        });

        TestElement _pngTest = new TestElement("png file test", (entry) =>
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "236-baby.png");
            ExtractEmbeddedResourceToPath(typeof(ClipboardTest).Assembly, "Forms9PatchDemo.Resources.236-baby.png", path);
            if (!File.Exists(path))
                throw new Exception("EmbeddedResource (236-baby.png) was not extracted to file");
            var result = entry.AddContentOfFile("image/png", path);
            _testImage.Source = Xamarin.Forms.ImageSource.FromStream(() => new MemoryStream(result));
            return result;
        }, (object obj) =>
        {
            if (obj is byte[] testByteArray)
            {
                var mimeItem = Forms9Patch.Clipboard.Entry.GetItem<byte[]>("image/png");
                var mimeResult = mimeItem?.Value;
                _resultImage.Source = Xamarin.Forms.ImageSource.FromStream(() => new MemoryStream(mimeResult));
                if (testByteArray.Length == mimeResult.Length)
                    return NewMemCmp(testByteArray, mimeResult, testByteArray.Length);
                return false;
            }
            return false;
        });

        TestElement _pdfTest = new TestElement("pdf file test", (entry) =>
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "ProjectProposal.pdf");
            ExtractEmbeddedResourceToPath(typeof(ClipboardTest).Assembly, "Forms9PatchDemo.Resources.ProjectProposal.pdf", path);
            if (!File.Exists(path))
                throw new Exception("EmbeddedResource (ProjectProposal.pdf) was not extracted to file");
            return entry.AddContentOfFile("application/pdf", path);
        }, (object obj) =>
        {
            if (obj is byte[] testByteArray)
            {
                var mimeItem = Forms9Patch.Clipboard.Entry.GetItem<byte[]>("application/pdf");
                var resultByteArray = mimeItem?.Value;
                if (testByteArray.Length == resultByteArray.Length)
                    return NewMemCmp(testByteArray, resultByteArray, testByteArray.Length);
                return false;
            }
            return false;
        });

        TestElement _jpgUrlTest = new TestElement("jpeg file test", (entry) =>
        {
            entry.Uri = new Uri("https://i.redditmedia.com/npNromwDHMXlxFMa0CAZqw0MMSKFj-aHx5rvgQNPXyA.jpg?fit=crop&crop=faces%2Centropy&arh=2&w=640&s=04fe226f00868a3182265a9af861608e");
            _testImage.Source = Xamarin.Forms.ImageSource.FromUri(entry.Uri);
            return entry.Uri;
        }, (object obj) =>
        {
            if (obj is Uri testUri)
            {
                var resultUri = Forms9Patch.Clipboard.Entry.Uri;
                _resultImage.Source = Xamarin.Forms.ImageSource.FromUri(resultUri);
                return testUri == resultUri;
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

            _availableMimeTypesLabel.Text = string.Join(", ", Forms9Patch.Clipboard.Entry.MimeTypes);

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

            _layout.Children.Add(_jpegTest);
            _layout.Children.Add(_pngTest);
            _layout.Children.Add(_jpgUrlTest);
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
            _availableMimeTypesLabel.Text = string.Join(", ", Forms9Patch.Clipboard.Entry.MimeTypes);
        }


        bool CopyPaste()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var entry = new Forms9Patch.ClipboardEntry();


            var testByte = (byte)_byteTest.CopyAction.Invoke(entry);
            var testByteArray = (byte[])_byteArrayTest.CopyAction.Invoke(entry);
            var testChar = (char)_charTest.CopyAction.Invoke(entry);
            var testShort = (short)_shortTest.CopyAction.Invoke(entry);
            var testInt = (int)_intTest.CopyAction.Invoke(entry);
            var testLong = (long)_longTest.CopyAction.Invoke(entry);
            var testDouble = (double)_doubleTest.CopyAction.Invoke(entry);
            var testString = (string)_stringTest.CopyAction.Invoke(entry);
            var testIntList = (List<int>)_intListTest.CopyAction.Invoke(entry);
            var testDoubleList = (List<double>)_doubleListTest.CopyAction.Invoke(entry);
            var testStringList = (List<string>)_stringListTest.CopyAction.Invoke(entry);
            var testDictionary = (Dictionary<string, double>)_dictionaryTest.CopyAction.Invoke(entry);
            var testDictionaryList = (List<Dictionary<string, string>>)_dictionaryListTest.CopyAction.Invoke(entry);
            var testDateTime = (DateTime)_dateTimeTest.CopyAction.Invoke(entry);
            var testJpegByteArray = (byte[])_jpegTest.CopyAction.Invoke(entry);
            var testPngByteArray = (byte[])_pngTest.CopyAction.Invoke(entry);

            Forms9Patch.Clipboard.Entry = entry;

            _byteTest.Success = _byteTest.PasteFunction(testByte);
            _byteArrayTest.Success = _byteArrayTest.PasteFunction(testByteArray);
            _charTest.Success = _charTest.PasteFunction(testChar);
            _shortTest.Success = _shortTest.PasteFunction(testShort);
            _intTest.Success = _intTest.PasteFunction(testInt);
            _longTest.Success = _longTest.PasteFunction(testLong);
            _doubleTest.Success = _doubleTest.PasteFunction(testDouble);
            _stringTest.Success = _stringTest.PasteFunction(testString);
            _intListTest.Success = _intListTest.PasteFunction(testIntList);
            _doubleListTest.Success = _doubleListTest.PasteFunction(testDoubleList);
            _stringListTest.Success = _stringListTest.PasteFunction(testStringList);
            _dictionaryTest.Success = _dictionaryTest.PasteFunction(testDictionary);
            _dictionaryListTest.Success = _dictionaryListTest.PasteFunction(testDictionaryList);
            _dateTimeTest.Success = _dateTimeTest.PasteFunction(testDateTime);
            _jpegTest.Success = _jpegTest.PasteFunction(testJpegByteArray);
            _pngTest.Success = _pngTest.PasteFunction(testPngByteArray);

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
                        var obj = CopyAction.Invoke(entry);
                        Forms9Patch.Clipboard.Entry = entry;
                        Success = PasteFunction.Invoke(obj);
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
