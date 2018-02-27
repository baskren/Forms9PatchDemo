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
        static Random _rand = new Random(seed);

        Forms9Patch.Label _byteTest = new Forms9Patch.Label("☐ byte test ");
        Forms9Patch.Label _byteArrayTest = new Forms9Patch.Label("☐ byte[] test ");
        Forms9Patch.Label _charTest = new Forms9Patch.Label("☐ char test ");
        Forms9Patch.Label _shortTest = new Forms9Patch.Label("☐ short test ");
        Forms9Patch.Label _intTest = new Forms9Patch.Label("☐ int test ");
        Forms9Patch.Label _longTest = new Forms9Patch.Label("☐ long test ");
        Forms9Patch.Label _doubleTest = new Forms9Patch.Label("☐ double test ");
        Forms9Patch.Label _stringTest = new Forms9Patch.Label("☐ string test ");
        Forms9Patch.Label _intListTest = new Forms9Patch.Label("☐ List&lt;int&gt; test ");
        Forms9Patch.Label _doubleListTest = new Forms9Patch.Label("☐ List&lt;double&gt; test ");
        Forms9Patch.Label _stringListTest = new Forms9Patch.Label("☐ List&lt;string&gt; test ");

        Xamarin.Forms.StackLayout _layout = new Xamarin.Forms.StackLayout
        {
            Children =  { new Forms9Patch.Label("<b>Copy / Paste tests:</b>") }
        };

        public ClipboardTest()
        {
            var stopWatch = new Stopwatch();

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

            Content = _layout;

            stopWatch.Start();
            CopyPaste();
            stopWatch.Stop();

            _layout.Children.Add(new Forms9Patch.Label("<br/>ElapsedTime: " + stopWatch.ElapsedMilliseconds + "ms"));            
        }



        bool CopyPaste()
        {
            var entry = new Forms9Patch.ClipboardEntry();

            var testByteArray = new byte[200];
            _rand.NextBytes(testByteArray);
            entry.AddValue("application/x-forms9patchdemo-byte", testByteArray[0]);
            entry.AddValue("application/x-forms9patchdemo-bytebuffer", testByteArray);

            var testChar = (char)_rand.Next(255);
            entry.AddValue("application/x-forms9patchdemo-char", testChar);

            var testShort = (short)_rand.Next(255);
            entry.AddValue("application/x-forms9patchdemo-short", testShort);

            var testInt = _rand.Next();
            entry.AddValue("application/x-forms9patchdemo-int", testInt);

            var testLong = (long)_rand.Next() + (long)int.MaxValue;
            entry.AddValue("application/x-forms9patchdemo-long", testLong);

            var testDouble = _rand.NextDouble();
            entry.AddValue("application/x-forms9patchdemo-double", testDouble);

            var testString = "This is application/x-forms9patchdemo-string: ⅓ ⅔ ⓪ ① ② ③ ④ ⑤ ⑥ ⑦ ⑧ ⑨ ⑩ ⑪ ⑫ ⑬ ⑭ ⑮ ⑯ ⑰ ⑱ ⑲ ⑳  🅰 🅱 🅲 🅳 🅴 🅵 🅶 🅷 🅸 🅹 🅺 🅻 🅼 🅽 🅾 🅿 🆀 🆁 🆂 🆃 🆄 🆅 🆆 🆇 🆈 🆉 🙃 😐 😑 🤔 🙄 😮 😔 😖 😕";
            entry.AddValue("application/x-forms9patchdemo-string", testString);

            var testIntList = new List<int>();
            for (int i = 0; i < 20; i++)
                testIntList.Add(i);
            entry.AddValue("application/x-forms9patchdemo-int-list", testIntList);

            var testDoubleList = new List<double>();
            for (int i = 0; i < 20; i++)
                testDoubleList.Add(i + i / 10.0);
            entry.AddValue("application/x-forms9patchdemo-double-list", testDoubleList);

            var testStringList = new List<string>();
            for (int i = 0; i < 20; i++)
                testStringList.Add(RandomString(10));
            entry.AddValue("application/x-forms9patchdemo-string-list", testStringList);

            entry.AddValue("application/x-forms9patchdemo-datetime-string", DateTime.Now.ToLocalTime().ToString());

            Clipboard.Entry = entry;

            var resultByteArray = (byte[])Clipboard.Entry.GetItem("application/x-forms9patchdemo-bytebuffer").Value;
            if (resultByteArray.Count() != testByteArray.Count())
                throw new Exception("byte array counts don't match");
            for (int i = 0; i < resultByteArray.Count(); i++)
                if (resultByteArray[i] != testByteArray[i])
                    throw new Exception("byte arrays don't match at index [" + i + "]");
            _byteArrayTest.HtmlText = _byteArrayTest.HtmlText.Replace('☐', '☑');

            var resultByte = Clipboard.Entry.GetItem("application/x-forms9patchdemo-byte").Value;
            if ((byte)resultByte != testByteArray[0])
                throw new Exception("bytes don't match");
            _byteTest.HtmlText = _byteTest.HtmlText.Replace('☐', '☑');

            var resultChar = (char)Clipboard.Entry.GetItem("application/x-forms9patchdemo-char").Value;
            if (resultChar != testChar)
                throw new Exception("chars don't match");
            _charTest.HtmlText = _charTest.HtmlText.Replace('☐', '☑');

            var resultShort = (short)Clipboard.Entry.GetItem("application/x-forms9patchdemo-short").Value;
            if (resultShort != testShort)
                throw new Exception("shorts don't match");
            _shortTest.HtmlText = _shortTest.HtmlText.Replace('☐', '☑');

            var resultInt = (int)Clipboard.Entry.GetItem("application/x-forms9patchdemo-int").Value;
            if (resultInt != testInt)
                throw new Exception("ints don't match");
            _intTest.HtmlText = _intTest.HtmlText.Replace('☐', '☑');

            var resultLong = (long)Clipboard.Entry.GetItem("application/x-forms9patchdemo-long").Value;
            if (resultLong != testLong)
                throw new Exception("longs don't match");
            _longTest.HtmlText = _longTest.HtmlText.Replace('☐', '☑');

            var resultDouble = (double)Clipboard.Entry.GetItem("application/x-forms9patchdemo-double").Value;
            if (resultDouble != testDouble)
                throw new Exception("doubles don't match");
            _doubleTest.HtmlText = _doubleTest.HtmlText.Replace('☐', '☑');

            var resultString = (string)Clipboard.Entry.GetItem("application/x-forms9patchdemo-string").Value;
            if (resultString != testString)
                throw new Exception("Strings don't match");
            _stringTest.HtmlText = _stringTest.HtmlText.Replace('☐', '☑');

            var resultIntList = (List<int>)Clipboard.Entry.GetItem("application/x-forms9patchdemo-int-list").Value;
            if (resultIntList.Count != testIntList.Count)
                throw new Exception("int list counts don't match");
            for (int i = 0; i < resultIntList.Count; i++)
                if (resultIntList[i] != testIntList[i])
                    throw new Exception("int lists don't match at index [" + i + "]");
            _intListTest.HtmlText = _intListTest.HtmlText.Replace('☐', '☑');

            var resulDoubleList = (List<double>)Clipboard.Entry.GetItem("application/x-forms9patchdemo-double-list").Value;
            if (resulDoubleList.Count != testDoubleList.Count)
                throw new Exception("double list counts don't match");
            for (int i = 0; i < resulDoubleList.Count; i++)
                if (resulDoubleList[i] != testDoubleList[i])
                    throw new Exception("double lists don't match at index [" + i + "]");
            _doubleListTest.HtmlText = _doubleListTest.HtmlText.Replace('☐', '☑');

            var resultStringList = (List<string>)Clipboard.Entry.GetItem("application/x-forms9patchdemo-string-list").Value;
            if (resultStringList.Count != testStringList.Count)
                throw new Exception("string list counts don't match");
            for (int i = 0; i < resultIntList.Count; i++)
                if (resultStringList[i] != testStringList[i])
                    throw new Exception("string lists don't match at index [" + i + "]");
            _stringListTest.HtmlText = _stringListTest.HtmlText.Replace('☐', '☑');

            return true;
        }

        static string RandomString(int length)
        {
            const string chars = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~¡¢£¤¥¦§¨©ª«⅓⅔⓪①②③④⑤⑥⑦⑧⑨⑩⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_rand.Next(s.Length)]).ToArray());
        }
    }
}
