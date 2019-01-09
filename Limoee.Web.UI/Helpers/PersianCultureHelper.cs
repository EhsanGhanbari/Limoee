// PersianCalendarHelper
// Provides methods to fix the persian culture for Persian calendar.
// You can freely use this code.
// By Babak Mahmoudi (babak@gnco.ir)
// See Also: 
//  * http://code.msdn.microsoft.com/Fixing-Persian-Locale-for-6e66e044
//  * http://babakmahmoudi.wordpress.com/2011/08/22/whats-wrong-with-persian-culture-in-net/
//  * http://kb.gn.co.ir/BabakMahmoudi/Lists/Posts/Post.aspx?ID=5
//  * http://www.codeproject.com/KB/dotnet/PersianCulture.aspx ( an article by Reza Taroosheh)
//  

using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace Limoee.Web.UI.Helpers
{
    [Flags]
    public enum FixCultureOptions
    {
        /// <summary>
        /// If set Calendar property of culture will be set to PersianCalendar.
        /// </summary>
        FoptCalendarInCulture = 2,
        /// <summary>
        /// If set Calendar of DateFormatInfo will be set to PersianCalendar
        /// </summary>
        FoptCalendarInDateFormatInfo = 4,
        /// <summary>
        /// If set the first element of OptionalCalendars will be set to PersianCalendar
        /// </summary>
        FoptOptionalCalendars = 8,
        /// <summary>
        /// All fix ups will applied.
        /// </summary>
        FoptAll = 16
    }

    /// <summary>
    /// Contains methods to fix the Persian culture for Persian calendar.
    /// </summary>
    public class PersianCultureHelper
    {
        [DllImport("kernel32.dll")]
        static extern bool VirtualProtect(IntPtr lpAddress, uint dwSize, uint flNewProtect, out uint lpflOldProtect);

        /// <summary>
        /// Fixes the DateTimeFormatInfo for Persian resources (months and week day names), and optionally sets the calendar to PersianCalendar.
        /// </summary>
        /// <param name="info">The DateTimeFormatInfo to be fixed.</param>
        /// <param name="UsePersianCalendar">If set, the calendar will be set to PersianCalendar.</param>
        /// <returns>The fixed DateTimeFormatInfo.</returns>
        public static DateTimeFormatInfo FixPersianDateTimeFormat(DateTimeFormatInfo info, bool UsePersianCalendar)
        {
            FieldInfo dateTimeFormatInfoReadOnly = typeof(DateTimeFormatInfo).GetField("m_isReadOnly", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            FieldInfo dateTimeFormatInfoCalendar = typeof(DateTimeFormatInfo).GetField("calendar", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance); ;

            if (info == null)
                info = new DateTimeFormatInfo();
            info.Calendar = new HijriCalendar();

            bool readOnly = (bool)dateTimeFormatInfoReadOnly.GetValue(info);
            if (readOnly)
            {
                dateTimeFormatInfoReadOnly.SetValue(info, false);
            }
            if (UsePersianCalendar)
            {
                dateTimeFormatInfoCalendar.SetValue(info, new PersianCalendar());
            }
            if (info.Calendar.GetType() == typeof(PersianCalendar))
            {
                info.AbbreviatedDayNames = new string[] { "ی", "د", "س", "چ", "پ", "ج", "ش" };
                info.ShortestDayNames = new string[] { "ی", "د", "س", "چ", "پ", "ج", "ش" };
                info.DayNames = new string[] { "یکشنبه", "دوشنبه", "ﺳﻪشنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" };
                info.AbbreviatedMonthNames = new string[] { "فروردین", "ارديبهشت", "خرداد", "تير", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "" };
                info.MonthNames = new string[] { "فروردین", "ارديبهشت", "خرداد", "تير", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند", "" };
                info.AMDesignator = "ق.ظ";
                info.PMDesignator = "ب.ظ";
                info.FirstDayOfWeek = DayOfWeek.Saturday;
                info.FullDateTimePattern = "yyyy MMMM dddd, dd HH:mm:ss";
                info.LongDatePattern = "yyyy MMMM dddd, dd";
                info.ShortDatePattern = "yyyy/MM/dd";
            }
            if (readOnly)
            {
                dateTimeFormatInfoReadOnly.SetValue(info, true);
            }
            return info;
        }
        /// <summary>
        /// Fixes CultureInfo for Persian resoures (months and day names) and also PersianCalendar.
        /// </summary>
        /// <param name="culture">The CultureInfo instace to be fixed. If NULL, a new instance will be created and returned.</param>
        /// <param name="options">Specifies what to be fixed.</param>
        /// <returns>A new instance of fixed Persian CultureInfo.</returns>
        public static CultureInfo FixPersianCulture(CultureInfo culture, FixCultureOptions options)
        {
            PropertyInfo calendarID = typeof(Calendar).GetProperty("ID", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo cultureInfoReadOnly = typeof(CultureInfo).GetField("m_isReadOnly", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            FieldInfo cultureInfoCalendar = typeof(CultureInfo).GetField("calendar", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            //FieldInfo cultureInfoReadOnly = typeof(CultureInfo).GetField("m_", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            if (culture == null)
                culture = new CultureInfo("fa-IR", false);
            if (culture == null || culture.LCID != 1065)
                return culture;
            if ((options & FixCultureOptions.FoptAll) == FixCultureOptions.FoptAll)
                options = FixCultureOptions.FoptCalendarInCulture | FixCultureOptions.FoptCalendarInDateFormatInfo |
                     FixCultureOptions.FoptOptionalCalendars;
            if ((options & FixCultureOptions.FoptOptionalCalendars) == FixCultureOptions.FoptOptionalCalendars)
            {
                FixOptionalCalendars(culture, 4);
                culture = new CultureInfo("fa-IR", false);
            }

            bool readOnly = (bool)cultureInfoReadOnly.GetValue(culture);
            if (readOnly)
            {
                cultureInfoReadOnly.SetValue(culture, false);
            }
            if ((options & FixCultureOptions.FoptCalendarInDateFormatInfo) == FixCultureOptions.FoptCalendarInDateFormatInfo)
                culture.DateTimeFormat = FixPersianDateTimeFormat(culture.DateTimeFormat, true);
            else
                FixPersianDateTimeFormat(culture.DateTimeFormat, false);
            if ((options & FixCultureOptions.FoptCalendarInCulture)
                                     == FixCultureOptions.FoptCalendarInCulture)
            {
                cultureInfoCalendar.SetValue(culture, new PersianCalendar());
            }
            if (readOnly)
            {
                cultureInfoReadOnly.SetValue(culture, true);
            }

            culture.NumberFormat.CurrencyDecimalDigits = 0;
            culture.NumberFormat.CurrencySymbol = "";
            culture.NumberFormat.CurrencyPositivePattern = 0;
            culture.NumberFormat.PositiveSign = "";

            return culture;
        }
        /// <summary>
        /// Creates, fixes and returns a new instance of Persian culture.
        /// </summary>
        /// <returns>A new instance of fixed Persian culture.</returns>
        public static CultureInfo GetFixedPersianCulture()
        {
            return FixPersianCulture(null, FixCultureOptions.FoptAll);
        }
        /// <summary>
        /// Set the CurrentCulture of current thread to a new fixed Persian culture.
        /// </summary>
        /// <returns>The fixed Persian cultreinfo.</returns>
        public static CultureInfo FixAndSetCurrentCulture()
        {
            CultureInfo culture = FixPersianCulture(null, FixCultureOptions.FoptAll);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            return culture;



        }
        /// <summary>
        /// Fixes the OptionalCalendars in case of .Net 4.
        /// </summary>
        private static CultureInfo _FixOptionalCalendars4(CultureInfo culture, int CalenadrIndex)
        {
            FieldInfo cultureDataField = typeof(CultureInfo).GetField("m_cultureData",
                 BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            Object cultureData = cultureDataField.GetValue(culture);
            FieldInfo waCalendarsField = cultureData.GetType().GetField("waCalendars",
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            int[] waCalendars = (int[])waCalendarsField.GetValue(cultureData);

            if (waCalendars != null && (CalenadrIndex >= 0 && CalenadrIndex < waCalendars.Length))
                waCalendars[CalenadrIndex] = 0x16;
            waCalendarsField.SetValue(cultureData, waCalendars);
            return culture;
        }
        
        /// <summary>
        /// Sets the CalendarIndex element of OptionalCalendars of the passed caulture to PersianCalendar.
        /// </summary>
        /// <param name="culture">The CultureInfo instance to be fixed.</param>
        /// <param name="calenadrIndex">The index of element in optional calendars to be set to PersianCalendar. Note that this can not add a new element so that the idex should be les than the length of the OptionalCalendars array.</param>
        /// <returns>The fixed culture.</returns>
        public static CultureInfo FixOptionalCalendars(CultureInfo culture, int calenadrIndex)
        {
            var ivCultureInfo = new InvokeHelper(culture);
            if (!ivCultureInfo.HasField("m_cultureTableRecord"))
            {
                // This is .Net 4. 
                return _FixOptionalCalendars4(culture, calenadrIndex);
            }

            var ivTableRecord = new InvokeHelper(ivCultureInfo.GetField("m_cultureTableRecord"));
            // Get the m_pData pointer as *void
            Pointer m_pData = (Pointer)ivTableRecord.GetField("m_pData");
            ConstructorInfo _intPtrCtor = typeof(IntPtr).GetConstructor(
                            new Type[] { Type.GetType("System.Void*") });
            // Construct a new IntPtr
            IntPtr DataIntPtr = (IntPtr)_intPtrCtor.Invoke(new object[1] { m_pData });

            Type TCultureTableData = Type.GetType("System.Globalization.CultureTableData");
            // Convert the Pointer class to object if type CultureTableData to work with
            // reflection API.
            Object oCultureTableData = Marshal.PtrToStructure(DataIntPtr, TCultureTableData);
            InvokeHelper ivCultureTableData = new InvokeHelper(oCultureTableData);
            // Get waCalendars pointer
            uint waCalendars = (uint)ivCultureTableData.GetField("waCalendars");
            object IOPTIONALCALENDARS = ivTableRecord.GetProperty("IOPTIONALCALENDARS");

            // Get m_Pool pointer
            Pointer m_pool = (Pointer)ivTableRecord.GetField("m_pPool");

            IntPtr PoolInPtr = (IntPtr)_intPtrCtor.Invoke(new object[1] { m_pool });
            // Add the waCalendars offset to pool pointer
            IntPtr shortArrayPtr = new IntPtr((PoolInPtr.ToInt64() + waCalendars * sizeof(ushort)));
            short[] shortArray = new short[1];
            // Now shortArray points to an arry of short integers.
            // Go to read the first value which is the number of elements.
            // Marshal array to read elements.
            Marshal.Copy(shortArrayPtr, shortArray, 0, 1);
            // shortArray[0] is the number of optional calendars.
            short[] calArray = new short[shortArray[0]];
            // Add one element of short type to point to array of calendars
            IntPtr calArrayPtr = new IntPtr(shortArrayPtr.ToInt64() + sizeof(short));
            // Finally read the array
            Marshal.Copy(calArrayPtr, calArray, 0, shortArray[0]);

            uint old;
            VirtualProtect(calArrayPtr, 100, 0x4, out old);
            calArray[calenadrIndex] = 0x16;
            Marshal.Copy(calArray, 0, calArrayPtr, calArray.Length);
            VirtualProtect(calArrayPtr, 100, old, out old);

            return culture;



        }
        public static string GetCurrentHijriyear()
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(DateTime.Now).ToString();
        }

        public static string GetCurrentPersianDate()
        {
            var pc = new PersianCalendar();
            return string.Format("{0}/{1}/{2}", pc.GetYear(DateTime.Now), pc.GetMonth(DateTime.Now), pc.GetDayOfMonth(DateTime.Now).ToString("00"));
        }

        private class InvokeHelper
        {
            private readonly object _mInstance;
            readonly Type _mType;

            public InvokeHelper(object instance)
            {
                _mInstance = instance;
                _mType = instance.GetType();
            }

            public bool HasField(string fieldName)
            {
                return _mType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).Any(field => field.Name == fieldName);
            }

            public object GetProperty(string fieldName)
            {
                return _mType.InvokeMember(fieldName,
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty,
                    null, _mInstance, null);

            }

            private object GetField(string fieldName, object[] args)
            {
                return _mType.InvokeMember(fieldName,
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField,
                    null, _mInstance, args);
            }
            
            public object GetField(string fieldName)
            {
                return GetField(fieldName, null);
            }
            
            
        }
    }
}
