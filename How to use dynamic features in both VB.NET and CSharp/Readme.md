# How to use dynamic features in both VB.NET and CSharp
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- C#
- Visual Basic .NET
- VB.Net
- Visual C#
## Topics
- Data Binding
- Dynamic
- object
## Updated
- 08/02/2017
## Description

<h1>Introduction</h1>
<p><em>The key word &quot;dynamic&quot; is only for C# to wrap a specific kind of variable like object. And when you use the dynamic value, you cannot get any intellisenses because properties,methods will be automatically invoked. So if you are sure that some object
 MUST have a property or method. You can directly write them one by one, step by step. The compiler won't check any syntaxes until during the running time.</em></p>
<p><strong><em>And in fact for VB.NET, we also have such features, but you should do these things first:</em></strong></p>
<p><strong><em>1) Everything define as an &quot;Object&quot; value.</em></strong></p>
<p><strong><em>2) Close &quot;Option Exclipit&quot; by switching it to &quot;Off&quot; so as to make Visual Basic have the function of Late binding&quot; in &quot;Properties&quot;=&gt;&quot;Compiler&quot;</em></strong></p>
<p><em><img id="176464" src="176464-%e6%8d%95%e8%8e%b7.png" alt="" width="361" height="79"><br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>At least VS 2010 (net framework MUST BE 4.0 or later version).</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>1) The 1st senario to use this dynamic value is that you wanna do something like &#43;,-,*,/ (Have you remembered ?). In fact, if you are sure that the generic struct has implemented these overloadable operators, just write them and return a value without type
 checking.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden"> ''' &lt;summary&gt;
        ''' dynamic will automtically check whether the generic type supports operators such as &#43;,-,*,/. If Not, exceptions will be thrown out.
        ''' So for dynamic, if we are sure that something has supported some methods&hellip;&hellip;ect. We'RE SURE to directly use that without any intellisenses.
        ''' And it's not an easy task to cope with a generic type with operators, because we don't know whether they have implemented these operators or not. So we have to SUPPOSE they've implemented them.
        ''' &lt;/summary&gt;
        Public Function Add(Of T As {Structure})(ByVal num1 As T, ByVal num2 As T) As T

            Dim dnum1 As Object = num1
            Dim dnum2 As Object = num2
            Return dnum1 &#43; dnum2
        End Function</pre>
<pre class="hidden">        /// &lt;summary&gt;
        /// dynamic will automtically check whether the generic type supports operators such as &#43;,-,*,/. If not, exceptions will be thrown out.
        /// So for dynamic, if we are sure that something has supported some methods&hellip;&hellip;ect. We'RE SURE to directly use that without any intellisenses.
        /// And it's not an easy task to cope with a generic type with operators, because we don't know whether they have implemented these operators or not. So we have to SUPPOSE they've implemented them.
        /// &lt;/summary&gt;
        public static T Add&lt;T&gt;(T num1, T num2) where T : struct
        {
            return (T)((dynamic)num1 &#43; (dynamic)num2);
        }</pre>
<div class="preview">
<pre class="vb">&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;dynamic&nbsp;will&nbsp;automtically&nbsp;check&nbsp;whether&nbsp;the&nbsp;generic&nbsp;type&nbsp;supports&nbsp;operators&nbsp;such&nbsp;as&nbsp;&#43;,-,*,/.&nbsp;If&nbsp;Not,&nbsp;exceptions&nbsp;will&nbsp;be&nbsp;thrown&nbsp;out.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;So&nbsp;for&nbsp;dynamic,&nbsp;if&nbsp;we&nbsp;are&nbsp;sure&nbsp;that&nbsp;something&nbsp;has&nbsp;supported&nbsp;some&nbsp;methods&hellip;&hellip;ect.&nbsp;We'RE&nbsp;SURE&nbsp;to&nbsp;directly&nbsp;use&nbsp;that&nbsp;without&nbsp;any&nbsp;intellisenses.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;And&nbsp;it's&nbsp;not&nbsp;an&nbsp;easy&nbsp;task&nbsp;to&nbsp;cope&nbsp;with&nbsp;a&nbsp;generic&nbsp;type&nbsp;with&nbsp;operators,&nbsp;because&nbsp;we&nbsp;don't&nbsp;know&nbsp;whether&nbsp;they&nbsp;have&nbsp;implemented&nbsp;these&nbsp;operators&nbsp;or&nbsp;not.&nbsp;So&nbsp;we&nbsp;have&nbsp;to&nbsp;SUPPOSE&nbsp;they've&nbsp;implemented&nbsp;them.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;Add(<span class="visualBasic__keyword">Of</span>&nbsp;T&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;{<span class="visualBasic__keyword">Structure</span>})(<span class="visualBasic__keyword">ByVal</span>&nbsp;num1&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;T,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;num2&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;T)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;T&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dnum1&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;=&nbsp;num1&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dnum2&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;=&nbsp;num2&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;dnum1&nbsp;&#43;&nbsp;dnum2&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span></pre>
</div>
</div>
</div>
<p><span style="font-size:10px">2) For C# or VB.NET, we can also use ExpendoObject, which ONLY supports for dynamic properties, methods by dynamically attaching it.</span></p>
<p>Notice that I used IDictionary&lt;string,value&gt; is to wrap the passed parameter values as &quot;Property-Value&quot; pair. And then dynamically attach them to the ExpendoObject.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">''' &lt;summary&gt;
        ''' Dynamically attaching Properties, Events, Functions into an ExpandoObject
        ''' &lt;/summary&gt;
        Public Function DynamicObjectCreator(ByVal propertyValuesMapping As IDictionary(Of String, Object)) As Object

            Dim dynamicObj As IDictionary(Of String, Object) = New ExpandoObject()

            For Each item As KeyValuePair(Of String, Object) In propertyValuesMapping
                dynamicObj(item.Key) = item.Value
            Next
            Return dynamicObj
        End Function</pre>
<pre class="hidden">        /// &lt;summary&gt;
        /// Dynamically attaching Properties, Events, Functions into an ExpandoObject
        /// &lt;/summary&gt;
        public static dynamic DynamicObjectCreator(IDictionary&lt;string, dynamic&gt; propertyValuesMapping)
        {
            IDictionary&lt;string, object&gt; dynamicObj = new ExpandoObject();
            foreach (KeyValuePair&lt;string, dynamic&gt; item in propertyValuesMapping)
            {
                dynamicObj[item.Key] = item.Value;
            }
            return dynamicObj;
        }</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Dynamically&nbsp;attaching&nbsp;Properties,&nbsp;Events,&nbsp;Functions&nbsp;into&nbsp;an&nbsp;ExpandoObject</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;DynamicObjectCreator(<span class="visualBasic__keyword">ByVal</span>&nbsp;propertyValuesMapping&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IDictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Object</span>))&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dynamicObj&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IDictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;ExpandoObject()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;item&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;KeyValuePair(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;propertyValuesMapping&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dynamicObj(item.Key)&nbsp;=&nbsp;item.Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;dynamicObj&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span></pre>
</div>
</div>
</div>
<p>3) The last example is a little complicated. It has shown you to customize your own &quot;Dynamic Object&quot; by inherting from DynamicObject from overwriting some speicifc methods.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Dynamic
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Text

Namespace CSharpDynamicUnitTest
    Public Class CustomizedDynamicObject
        Inherits DynamicObject
        ''' &lt;summary&gt;
        ''' Allowed simple types to be called directly with &quot;ToString()&quot; in the &quot;GetRealString&quot;.
        ''' &lt;/summary&gt;
        Private Shared ReadOnly _allowedTypes As Type()
        ''' &lt;summary&gt;
        ''' We use a Name-Value collection so that we can mock an object in javascript.
        ''' &lt;/summary&gt;
        Private _propertyValuesCollection As IDictionary(Of String, Object) = New Dictionary(Of String, Object)()

        Shared Sub New()
            CustomizedDynamicObject._allowedTypes = New Type() {GetType(Integer), GetType(UInteger), GetType(Long), GetType(ULong), GetType(Single), GetType(Double), GetType(Decimal)}
        End Sub

        Public Sub New()
            MyBase.New()
        End Sub

        Public Overrides Function GetDynamicMemberNames() As IEnumerable(Of String)
            Return Me._propertyValuesCollection.Keys
        End Function
        ''' &lt;summary&gt;
        ''' This method will check whether the current looped value Is of simple type, an IEnumerable value Or something else.
        ''' 1) For simple types such as string, numeric types, directly call ToString.
        ''' 2) For any array type that implements IEnumerable, we can just use &quot;[]&quot; to output each value. Considering that each value in the array may vary, so a recursive Is a MUST here.
        ''' &lt;/summary&gt;
        Private Function GetRealString(ByVal value As Object) As String
            Dim str As String
            If (value.[GetType]() = GetType(String)) Then
                str = String.Concat(&quot;'&quot;, value.ToString(), &quot;'&quot;)
            ElseIf (Array.IndexOf(Of Type)(CustomizedDynamicObject._allowedTypes, value.[GetType]()) = -1) Then
                Dim p As IEnumerable = TryCast(value, IEnumerable)
                If (p Is Nothing) Then
                    str = value.ToString()
                Else
                    Dim sbu As StringBuilder = New StringBuilder()
                    Dim accessor As IEnumerator = p.GetEnumerator()
                    sbu.Append(&quot;[&quot;)
                    If (accessor.MoveNext()) Then
                        sbu.Append(Me.GetRealString(accessor.Current))
                    End If
                    While accessor.MoveNext()
                        sbu.Append(&quot;,&quot;)
                        sbu.Append(Me.GetRealString(accessor.Current))
                    End While
                    sbu.Append(&quot;]&quot;)
                    str = sbu.ToString()
                End If
            Else
                str = value.ToString()
            End If
            Return str
        End Function
        ''' &lt;summary&gt;
        ''' This method will output a string value as a simple json formation.
        ''' Notice the algorithm will call GetRealString, And GetRealString will call the method by exchange recursive.
        ''' &lt;/summary&gt;
        ''' &lt;returns&gt;
        ''' A simple js-based object.
        ''' &lt;/returns&gt;
        Public Overrides Function ToString() As String
            Dim current As KeyValuePair(Of String, Object)
            Dim sbu As StringBuilder = New StringBuilder(Me._propertyValuesCollection.Count)
            sbu.Append(&quot;{&quot;)
            If (Me._propertyValuesCollection.Count &gt; 0) Then
                Dim pointer As IEnumerator(Of KeyValuePair(Of String, Object)) = Me._propertyValuesCollection.GetEnumerator()
                If (pointer.MoveNext()) Then
                    current = pointer.Current
                    Dim key As String = current.Key
                    current = pointer.Current
                    sbu.Append(String.Concat(key, &quot;:&quot;, Me.GetRealString(current.Value)))
                End If
                While pointer.MoveNext()
                    sbu.Append(&quot;,&quot;)
                    current = pointer.Current
                    Dim str As String = current.Key
                    current = pointer.Current
                    sbu.Append(String.Concat(str, &quot;:&quot;, Me.GetRealString(current.Value)))
                End While
            End If
            sbu.Append(&quot;}&quot;)
            Return sbu.ToString()
        End Function
        ''' &lt;summary&gt;
        ''' This method means you can exclipitly convert the dynamic value to a string by assigning it.
        ''' Notice that this only supports converted to string.
        ''' &lt;/summary&gt;
        Public Overrides Function TryConvert(ByVal binder As ConvertBinder, &lt;Out&gt; ByRef result As Object) As Boolean
            Dim flag As Boolean
            If (binder.Type = GetType(String)) Then
                result = Me.ToString()
                flag = True
            Else
                result = Nothing
                flag = False
            End If
            Return flag
        End Function

        Public Overrides Function TryDeleteIndex(ByVal binder As DeleteIndexBinder, ByVal indexes As Object()) As Boolean
            Dim flag As Boolean = Me._propertyValuesCollection.Remove(indexes(0).ToString())
            Return flag
        End Function

        Public Overrides Function TryDeleteMember(ByVal binder As DeleteMemberBinder) As Boolean
            Return Me._propertyValuesCollection.Remove(binder.Name)
        End Function

        Public Overrides Function TryGetIndex(ByVal binder As GetIndexBinder, ByVal indexes As Object(), &lt;Out&gt; ByRef result As Object) As Boolean
            Dim flag As Boolean = Me.TryGetValueByKey(indexes(0).ToString(), result)
            Return flag
        End Function
        ''' &lt;summary&gt;
        ''' Fetch the existing member.
        ''' &lt;/summary&gt;
        ''' &lt;param name=&quot;binder&quot;&gt;
        ''' The contenxt binder where we can get the inputted properties names.
        ''' &lt;/param&gt;
        ''' &lt;param name=&quot;result&quot;&gt;
        ''' The result as a return type for the assigned property value.
        ''' &lt;/param&gt;
        ''' &lt;returns&gt;
        ''' true: Successfully assigned.
        ''' false: exception will be thrown out.
        ''' &lt;/returns&gt;
        Public Overrides Function TryGetMember(ByVal binder As GetMemberBinder, &lt;Out&gt; ByRef result As Object) As Boolean
            Return Me.TryGetValueByKey(binder.Name, result)
        End Function

        Private Function TryGetValueByKey(ByVal keyName As String, &lt;Out&gt; ByRef result As Object) As Boolean
            Dim isSuccess As Boolean = True
            If (Me._propertyValuesCollection.ContainsKey(keyName)) Then
                result = Me._propertyValuesCollection(keyName)
            Else
                result = Nothing
                isSuccess = False
            End If
            Return isSuccess
        End Function

        Public Overrides Function TrySetIndex(ByVal binder As SetIndexBinder, ByVal indexes As Object(), ByVal value As Object) As Boolean
            Dim flag As Boolean = Me.TrySetValueByKey(indexes(0).ToString(), value)
            Return flag
        End Function

        Public Overrides Function TrySetMember(ByVal binder As SetMemberBinder, ByVal value As Object) As Boolean
            Return Me.TrySetValueByKey(binder.Name, value)
        End Function

        Private Function TrySetValueByKey(ByVal keyName As String, ByVal result As Object) As Boolean
            Me._propertyValuesCollection(keyName) = result
            Return True
        End Function
    End Class
End Namespace</pre>
<pre class="hidden">using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace CSharpDynamicUnitTest
{
    public class CustomizedDynamicObject : DynamicObject
    {
        /// &lt;summary&gt;
        /// Allowed simple types to be called directly with &quot;ToString()&quot; in the &quot;GetRealString&quot;.
        /// &lt;/summary&gt;
        private readonly static Type[] _allowedTypes = new Type[]
            {
            typeof(int),typeof(uint),typeof(long),typeof(ulong),typeof(float),typeof(double),typeof(decimal)
            };
        /// &lt;summary&gt;
        /// We use a Name-Value collection so that we can mock an object in javascript.
        /// &lt;/summary&gt;
        private IDictionary&lt;string, dynamic&gt; _propertyValuesCollection = new Dictionary&lt;string, dynamic&gt;();
        /// &lt;summary&gt;
        /// Get all the property names (this will be something like for&hellip;&hellip;in javascript, to use the properties name to access each property name).
        /// &lt;/summary&gt;
        public override IEnumerable&lt;string&gt; GetDynamicMemberNames()
        {
            return _propertyValuesCollection.Keys;
        }

        #region Try to get/set value by key
        private bool TryGetValueByKey(string keyName, out object result)
        {
            bool isSuccess = true;

            if (!_propertyValuesCollection.ContainsKey(keyName))
            {
                result = null;
                isSuccess = false;
            }
            else
            {
                result = _propertyValuesCollection[keyName];
            }

            return isSuccess;
        }

        private bool TrySetValueByKey(string keyName, object result)
        {
            _propertyValuesCollection[keyName] = result;
            return true;
        }
        #endregion


        /// &lt;summary&gt;
        /// This method means you can exclipitly convert the dynamic value to a string by assigning it.
        /// Notice that this only supports converted to string.
        /// &lt;/summary&gt;
        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if (binder.Type != typeof(string))
            {
                result = null;
                return false;
            }
            result = ToString();
            return true;
        }
        /// &lt;summary&gt;
        /// Fetch the existing member.
        /// &lt;/summary&gt;
        /// &lt;param name=&quot;binder&quot;&gt;
        /// The contenxt binder where we can get the inputted properties names.
        /// &lt;/param&gt;
        /// &lt;param name=&quot;result&quot;&gt;
        /// The result as a return type for the assigned property value.
        /// &lt;/param&gt;
        /// &lt;returns&gt;
        /// true: Successfully assigned.
        /// false: exception will be thrown out.
        /// &lt;/returns&gt;
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return TryGetValueByKey(binder.Name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            return TrySetValueByKey(binder.Name, value);
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            return TryGetValueByKey(indexes[0].ToString(), out result);
        }

        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            return TrySetValueByKey(indexes[0].ToString(), value);
        }

        public override bool TryDeleteMember(DeleteMemberBinder binder)
        {
            return _propertyValuesCollection.Remove(binder.Name);
        }

        public override bool TryDeleteIndex(DeleteIndexBinder binder, object[] indexes)
        {
            return _propertyValuesCollection.Remove(indexes[0].ToString());
        }

        #region To override the ToString method to return a js object formation
        /// &lt;summary&gt;
        /// This method will check whether the current looped value is of simple type, an IEnumerable value or something else.
        /// 1) For simple types such as string, numeric types, directly call ToString.
        /// 2) For any array type that implements IEnumerable, we can just use &quot;[]&quot; to output each value. Considering that each value in the array may vary, so a recursive is a MUST here.
        /// &lt;/summary&gt;
        private string GetRealString(object value)
        {
            if (value.GetType() == typeof(string))
            {
                return &quot;'&quot; &#43; value.ToString() &#43; &quot;'&quot;;
            }
            else if (Array.IndexOf(_allowedTypes, value.GetType()) != -1)
            {
                return value.ToString();
            }
            IEnumerable p = value as IEnumerable;
            if (p != null)
            {
                StringBuilder sbu = new StringBuilder();
                IEnumerator accessor = p.GetEnumerator();
                sbu.Append(&quot;[&quot;);

                if (accessor.MoveNext())
                {
                    sbu.Append(GetRealString(accessor.Current));
                }
                while (accessor.MoveNext())
                {
                    sbu.Append(&quot;,&quot;);
                    sbu.Append(GetRealString(accessor.Current));
                }

                sbu.Append(&quot;]&quot;);
                return sbu.ToString();
            }
            return value.ToString();
        }
        /// &lt;summary&gt;
        /// This method will output a string value as a simple json formation.
        /// Notice the algorithm will call GetRealString, and GetRealString will call the method by exchange recursive.
        /// &lt;/summary&gt;
        /// &lt;returns&gt;
        /// A simple js-based object.
        /// &lt;/returns&gt;
        public override string ToString()
        {
            StringBuilder sbu = new StringBuilder(_propertyValuesCollection.Count);

            sbu.Append(&quot;{&quot;);

            if (_propertyValuesCollection.Count &gt; 0)
            {
                IEnumerator&lt;KeyValuePair&lt;string, object&gt;&gt; pointer = _propertyValuesCollection.GetEnumerator();

                if (pointer.MoveNext())
                {
                    sbu.Append(pointer.Current.Key &#43; &quot;:&quot; &#43; GetRealString(pointer.Current.Value));
                }

                while (pointer.MoveNext())
                {
                    sbu.Append(&quot;,&quot;);
                    sbu.Append(pointer.Current.Key &#43; &quot;:&quot; &#43; GetRealString(pointer.Current.Value));
                }

            }

            sbu.Append(&quot;}&quot;);

            return sbu.ToString();
        }
        #endregion
    }
}</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Collections&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Collections.Generic&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Dynamic&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Runtime.CompilerServices&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Runtime.InteropServices&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Text&nbsp;
&nbsp;
<span class="visualBasic__keyword">Namespace</span>&nbsp;CSharpDynamicUnitTest&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;CustomizedDynamicObject&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;DynamicObject&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Allowed&nbsp;simple&nbsp;types&nbsp;to&nbsp;be&nbsp;called&nbsp;directly&nbsp;with&nbsp;&quot;ToString()&quot;&nbsp;in&nbsp;the&nbsp;&quot;GetRealString&quot;.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Shared</span>&nbsp;<span class="visualBasic__keyword">ReadOnly</span>&nbsp;_allowedTypes&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Type()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;We&nbsp;use&nbsp;a&nbsp;Name-Value&nbsp;collection&nbsp;so&nbsp;that&nbsp;we&nbsp;can&nbsp;mock&nbsp;an&nbsp;object&nbsp;in&nbsp;javascript.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_propertyValuesCollection&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IDictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Dictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Object</span>)()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Shared</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<span class="visualBasic__keyword">New</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CustomizedDynamicObject._allowedTypes&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Type()&nbsp;{<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">Integer</span>),&nbsp;<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">UInteger</span>),&nbsp;<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">Long</span>),&nbsp;<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">ULong</span>),&nbsp;<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">Single</span>),&nbsp;<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">Double</span>),&nbsp;<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">Decimal</span>)}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<span class="visualBasic__keyword">New</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.<span class="visualBasic__keyword">New</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;GetDynamicMemberNames()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IEnumerable(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Me</span>._propertyValuesCollection.Keys&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;This&nbsp;method&nbsp;will&nbsp;check&nbsp;whether&nbsp;the&nbsp;current&nbsp;looped&nbsp;value&nbsp;Is&nbsp;of&nbsp;simple&nbsp;type,&nbsp;an&nbsp;IEnumerable&nbsp;value&nbsp;Or&nbsp;something&nbsp;else.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;1)&nbsp;For&nbsp;simple&nbsp;types&nbsp;such&nbsp;as&nbsp;string,&nbsp;numeric&nbsp;types,&nbsp;directly&nbsp;call&nbsp;ToString.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;2)&nbsp;For&nbsp;any&nbsp;array&nbsp;type&nbsp;that&nbsp;implements&nbsp;IEnumerable,&nbsp;we&nbsp;can&nbsp;just&nbsp;use&nbsp;&quot;[]&quot;&nbsp;to&nbsp;output&nbsp;each&nbsp;value.&nbsp;Considering&nbsp;that&nbsp;each&nbsp;value&nbsp;in&nbsp;the&nbsp;array&nbsp;may&nbsp;vary,&nbsp;so&nbsp;a&nbsp;recursive&nbsp;Is&nbsp;a&nbsp;MUST&nbsp;here.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;GetRealString(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;str&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(value.[<span class="visualBasic__keyword">GetType</span>]()&nbsp;=&nbsp;<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">String</span>))&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Concat(<span class="visualBasic__string">&quot;'&quot;</span>,&nbsp;value.ToString(),&nbsp;<span class="visualBasic__string">&quot;'&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;(Array.IndexOf(<span class="visualBasic__keyword">Of</span>&nbsp;Type)(CustomizedDynamicObject._allowedTypes,&nbsp;value.[<span class="visualBasic__keyword">GetType</span>]())&nbsp;=&nbsp;-<span class="visualBasic__number">1</span>)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;p&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IEnumerable&nbsp;=&nbsp;<span class="visualBasic__keyword">TryCast</span>(value,&nbsp;IEnumerable)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(p&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str&nbsp;=&nbsp;value.ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;sbu&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;StringBuilder&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;StringBuilder()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;accessor&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IEnumerator&nbsp;=&nbsp;p.GetEnumerator()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__string">&quot;[&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(accessor.MoveNext())&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__keyword">Me</span>.GetRealString(accessor.Current))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;accessor.MoveNext()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__string">&quot;,&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__keyword">Me</span>.GetRealString(accessor.Current))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__string">&quot;]&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str&nbsp;=&nbsp;sbu.ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str&nbsp;=&nbsp;value.ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;str&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;This&nbsp;method&nbsp;will&nbsp;output&nbsp;a&nbsp;string&nbsp;value&nbsp;as&nbsp;a&nbsp;simple&nbsp;json&nbsp;formation.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Notice&nbsp;the&nbsp;algorithm&nbsp;will&nbsp;call&nbsp;GetRealString,&nbsp;And&nbsp;GetRealString&nbsp;will&nbsp;call&nbsp;the&nbsp;method&nbsp;by&nbsp;exchange&nbsp;recursive.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;A&nbsp;simple&nbsp;js-based&nbsp;object.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;ToString()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;current&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;KeyValuePair(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;sbu&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;StringBuilder&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;StringBuilder(<span class="visualBasic__keyword">Me</span>._propertyValuesCollection.Count)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__string">&quot;{&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(<span class="visualBasic__keyword">Me</span>._propertyValuesCollection.Count&nbsp;&gt;&nbsp;<span class="visualBasic__number">0</span>)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;pointer&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IEnumerator(<span class="visualBasic__keyword">Of</span>&nbsp;KeyValuePair(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Object</span>))&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>._propertyValuesCollection.GetEnumerator()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(pointer.MoveNext())&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;current&nbsp;=&nbsp;pointer.Current&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;key&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;current.Key&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;current&nbsp;=&nbsp;pointer.Current&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__keyword">String</span>.Concat(key,&nbsp;<span class="visualBasic__string">&quot;:&quot;</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.GetRealString(current.Value)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;pointer.MoveNext()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__string">&quot;,&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;current&nbsp;=&nbsp;pointer.Current&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;str&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;current.Key&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;current&nbsp;=&nbsp;pointer.Current&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__keyword">String</span>.Concat(str,&nbsp;<span class="visualBasic__string">&quot;:&quot;</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.GetRealString(current.Value)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__string">&quot;}&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;sbu.ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;This&nbsp;method&nbsp;means&nbsp;you&nbsp;can&nbsp;exclipitly&nbsp;convert&nbsp;the&nbsp;dynamic&nbsp;value&nbsp;to&nbsp;a&nbsp;string&nbsp;by&nbsp;assigning&nbsp;it.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Notice&nbsp;that&nbsp;this&nbsp;only&nbsp;supports&nbsp;converted&nbsp;to&nbsp;string.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;TryConvert(<span class="visualBasic__keyword">ByVal</span>&nbsp;binder&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ConvertBinder,&nbsp;&lt;Out&gt;&nbsp;<span class="visualBasic__keyword">ByRef</span>&nbsp;result&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;flag&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(binder.Type&nbsp;=&nbsp;<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">String</span>))&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;flag&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;flag&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;flag&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;TryDeleteIndex(<span class="visualBasic__keyword">ByVal</span>&nbsp;binder&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DeleteIndexBinder,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;indexes&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>())&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;flag&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>._propertyValuesCollection.Remove(indexes(<span class="visualBasic__number">0</span>).ToString())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;flag&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;TryDeleteMember(<span class="visualBasic__keyword">ByVal</span>&nbsp;binder&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DeleteMemberBinder)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Me</span>._propertyValuesCollection.Remove(binder.Name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;TryGetIndex(<span class="visualBasic__keyword">ByVal</span>&nbsp;binder&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;GetIndexBinder,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;indexes&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>(),&nbsp;&lt;Out&gt;&nbsp;<span class="visualBasic__keyword">ByRef</span>&nbsp;result&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;flag&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.TryGetValueByKey(indexes(<span class="visualBasic__number">0</span>).ToString(),&nbsp;result)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;flag&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Fetch&nbsp;the&nbsp;existing&nbsp;member.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;binder&quot;&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;The&nbsp;contenxt&nbsp;binder&nbsp;where&nbsp;we&nbsp;can&nbsp;get&nbsp;the&nbsp;inputted&nbsp;properties&nbsp;names.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;result&quot;&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;The&nbsp;result&nbsp;as&nbsp;a&nbsp;return&nbsp;type&nbsp;for&nbsp;the&nbsp;assigned&nbsp;property&nbsp;value.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;true:&nbsp;Successfully&nbsp;assigned.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;false:&nbsp;exception&nbsp;will&nbsp;be&nbsp;thrown&nbsp;out.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;TryGetMember(<span class="visualBasic__keyword">ByVal</span>&nbsp;binder&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;GetMemberBinder,&nbsp;&lt;Out&gt;&nbsp;<span class="visualBasic__keyword">ByRef</span>&nbsp;result&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Me</span>.TryGetValueByKey(binder.Name,&nbsp;result)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;TryGetValueByKey(<span class="visualBasic__keyword">ByVal</span>&nbsp;keyName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;&lt;Out&gt;&nbsp;<span class="visualBasic__keyword">ByRef</span>&nbsp;result&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;isSuccess&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(<span class="visualBasic__keyword">Me</span>._propertyValuesCollection.ContainsKey(keyName))&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>._propertyValuesCollection(keyName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isSuccess&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;isSuccess&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;TrySetIndex(<span class="visualBasic__keyword">ByVal</span>&nbsp;binder&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SetIndexBinder,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;indexes&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>(),&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;flag&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.TrySetValueByKey(indexes(<span class="visualBasic__number">0</span>).ToString(),&nbsp;value)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;flag&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;TrySetMember(<span class="visualBasic__keyword">ByVal</span>&nbsp;binder&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SetMemberBinder,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Me</span>.TrySetValueByKey(binder.Name,&nbsp;value)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;TrySetValueByKey(<span class="visualBasic__keyword">ByVal</span>&nbsp;keyName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;result&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>._propertyValuesCollection(keyName)&nbsp;=&nbsp;result&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Namespace</span></pre>
</div>
</div>
</div>
<p>4) Here're the test cases:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System
Imports System.Collections.Generic

Namespace CSharpDynamicUnitTest
    &lt;TestClass&gt;
    Public Class DynamicKeyWordUnitTest

        Public Sub New()
            MyBase.New()
        End Sub

        &lt;TestMethod&gt;
        Public Sub DynamicallyAddPropertiesMethodsAndEvents()
            Dim strs As Dictionary(Of String, Object) = New Dictionary(Of String, Object)() From
            {
                {&quot;NumberOne&quot;, 1},
                {&quot;StringValue&quot;, &quot;Hello World!&quot;},
                {&quot;Add&quot;, New Func(Of Double, Double, Double)(Function(n1, n2) n1 &#43; n2)}
            }

            Dim nums As List(Of Integer) = New List(Of Integer)(5)
            strs.Add(&quot;EventDelegate&quot;, New Action(Of Integer)(Sub(num As Integer) nums.Add(num)))


            Dim d As Object = DynamicObjectCreator(strs)

            '''Do late binding
            d.NumberCheckingLoop = New Action(Of Integer, Integer)(Sub(num1, num2)

                                                                       For i As Integer = num1 To num2
                                                                           If (i Mod 2 = 0) Then
                                                                               d.EventDelegate.DynamicInvoke(i)
                                                                           End If
                                                                       Next
                                                                   End Sub)

            Assert.AreEqual(1, d.NumberOne)
            Assert.AreEqual(&quot;Hello World!&quot;, d.StringValue)

            ''' Here we must use DynamicInvoke, because in VB.NET
            ''' we cannot directly call a Function or an Action by adding a pair of &quot;()&quot; with parameters in C#, because this will be reguarded as an expression
            Assert.AreEqual(3.0, d.Add.DynamicInvoke(1.0, 2.0))
            d.NumberCheckingLoop.DynamicInvoke(1, 10)
            Assert.AreEqual(5, nums.Count)

        End Sub

        &lt;TestMethod&gt;
        Public Sub DynamicallyTestForDynamicObject()
            '''Define a basic simple object
            Dim d As Object = New CustomizedDynamicObject()
            d.a = &quot;a&quot;
            d.b = 1

            '''Define a nest object
            Dim nestObj As Object = New CustomizedDynamicObject()
            nestObj.d = 1
            nestObj.e = 2
            nestObj.array = New Integer() {1, 2, 3, 4, 5, 6}

            '''Define an obj array
            Dim dArrayObj As New List(Of Object)
            For i As Integer = 1 To 5
                Dim dObj As Object = New CustomizedDynamicObject()
                dObj.f = i
                dObj.g = i.ToString()
                dArrayObj.Add(dObj)
            Next
            nestObj.objArray = dArrayObj
            d.c = nestObj

            '''Do an implicit conversion
            Dim result As String = CTypeDynamic(d, GetType(String))
            Assert.AreEqual(Of String)(&quot;{a:'a',b:1,c:{d:1,e:2,array:[1,2,3,4,5,6],objArray:[{f:1,g:'1'},{f:2,g:'2'},{f:3,g:'3'},{f:4,g:'4'},{f:5,g:'5'}]}}&quot;, result)
        End Sub
    End Class
End Namespace</pre>
<pre class="hidden">using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CSharpDynamicUnitTest
{
    [TestClass]
    public class DynamicKeyWordUnitTest
    {
        /// &lt;summary&gt;
        /// Four tests for dynamic objects by attaching dynamically with Properties, Events, Functions.
        /// &lt;/summary&gt;
        [TestMethod]
        public void DynamicallyAddPropertiesMethodsAndEvents()
        {
            Dictionary&lt;string, dynamic&gt; propertyValuesMapping = new Dictionary&lt;string, dynamic&gt;();

            //Add a property returnning 1
            propertyValuesMapping.Add(&quot;NumberOne&quot;, 1);
            //Add a StringValue returning &quot;Hello World!&quot;
            propertyValuesMapping.Add(&quot;StringValue&quot;, &quot;Hello World!&quot;);
            //Add a Function returning the two numbers of double added together.
            propertyValuesMapping.Add(&quot;Add&quot;, new Func&lt;double, double, double&gt;((n1, n2) =&gt; n1 &#43; n2));

            List&lt;int&gt; evenNumbers = new List&lt;int&gt;(5);

            //Define an action as a void function to be an event raised thing.
            propertyValuesMapping.Add(&quot;EventDelegate&quot;,
                new Action&lt;int&gt;((int num) =&gt;
                 {
                     evenNumbers.Add(num);
                 }));

            var d = BasicDynamicSamples.DynamicObjectCreator(propertyValuesMapping);

            //Do dynamically late event trigger binding
            d.NumberCheckingLoop = new Action&lt;int, int&gt;((int start, int end) =&gt;
             {
                 for (int i = start; i &lt;= end; i&#43;&#43;)
                 {
                     if (i % 2 == 0)
                     {
                         //Do to trigger the registered event
                         d.EventDelegate(i);
                     }
                 }
             });

            Assert.AreEqual(1, d.NumberOne);
            Assert.AreEqual(&quot;Hello World!&quot;, d.StringValue);
            Assert.AreEqual(3.0, d.Add(1.0, 2.0));
            d.NumberCheckingLoop(1, 10);
            Assert.AreEqual(5, evenNumbers.Count);
        }

        [TestMethod]
        public void DynamicallyTestForDynamicObject()
        {
            //Define a basic simple object
            dynamic d = new CustomizedDynamicObject();
            d.a = &quot;a&quot;;
            d.b = 1;

            //Define a nest object
            dynamic nestObj = new CustomizedDynamicObject();
            nestObj.d = 1;
            nestObj.e = 2;
            nestObj.array = new int[] { 1, 2, 3, 4, 5, 6 };

            //Define an obj array
            List&lt;dynamic&gt; listOfDynamicTypes = new List&lt;dynamic&gt;();
            for (int i = 1; i &lt; 6; i&#43;&#43;)
            {
                dynamic dynamicArray = new CustomizedDynamicObject();
                dynamicArray.f = i;
                dynamicArray.g = i.ToString();
                listOfDynamicTypes.Add(dynamicArray);
            }
            nestObj.objArray = listOfDynamicTypes;
            d.c = nestObj;


            //Do an implicit conversion
            string result = d;
            //Fetch the result
            Assert.AreEqual(&quot;{a:'a',b:1,c:{d:1,e:2,array:[1,2,3,4,5,6],objArray:[{f:1,g:'1'},{f:2,g:'2'},{f:3,g:'3'},{f:4,g:'4'},{f:5,g:'5'}]}}&quot;, result);
        }
    }
}</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;Microsoft.VisualStudio.TestTools.UnitTesting&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Collections.Generic&nbsp;
&nbsp;
<span class="visualBasic__keyword">Namespace</span>&nbsp;CSharpDynamicUnitTest&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;TestClass&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;DynamicKeyWordUnitTest&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<span class="visualBasic__keyword">New</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.<span class="visualBasic__keyword">New</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TestMethod&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;DynamicallyAddPropertiesMethodsAndEvents()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;strs&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Dictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Dictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Object</span>)()&nbsp;From&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<span class="visualBasic__string">&quot;NumberOne&quot;</span>,&nbsp;<span class="visualBasic__number">1</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<span class="visualBasic__string">&quot;StringValue&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Hello&nbsp;World!&quot;</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<span class="visualBasic__string">&quot;Add&quot;</span>,&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Func(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">Double</span>,&nbsp;<span class="visualBasic__keyword">Double</span>,&nbsp;<span class="visualBasic__keyword">Double</span>)(<span class="visualBasic__keyword">Function</span>(n1,&nbsp;n2)&nbsp;n1&nbsp;&#43;&nbsp;n2)}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;nums&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)(<span class="visualBasic__number">5</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;strs.Add(<span class="visualBasic__string">&quot;EventDelegate&quot;</span>,&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Action(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)(<span class="visualBasic__keyword">Sub</span>(num&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;nums.Add(num)))&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;d&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;=&nbsp;DynamicObjectCreator(strs)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''Do&nbsp;late&nbsp;binding</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.NumberCheckingLoop&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Action(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;<span class="visualBasic__keyword">Integer</span>)(<span class="visualBasic__keyword">Sub</span>(num1,&nbsp;num2)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;i&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;num1&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;num2&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(i&nbsp;<span class="visualBasic__keyword">Mod</span>&nbsp;<span class="visualBasic__number">2</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.EventDelegate.DynamicInvoke(i)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.AreEqual(<span class="visualBasic__number">1</span>,&nbsp;d.NumberOne)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.AreEqual(<span class="visualBasic__string">&quot;Hello&nbsp;World!&quot;</span>,&nbsp;d.StringValue)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Here&nbsp;we&nbsp;must&nbsp;use&nbsp;DynamicInvoke,&nbsp;because&nbsp;in&nbsp;VB.NET</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;we&nbsp;cannot&nbsp;directly&nbsp;call&nbsp;a&nbsp;Function&nbsp;or&nbsp;an&nbsp;Action&nbsp;by&nbsp;adding&nbsp;a&nbsp;pair&nbsp;of&nbsp;&quot;()&quot;&nbsp;with&nbsp;parameters&nbsp;in&nbsp;C#,&nbsp;because&nbsp;this&nbsp;will&nbsp;be&nbsp;reguarded&nbsp;as&nbsp;an&nbsp;expression</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.AreEqual(<span class="visualBasic__number">3.0</span>,&nbsp;d.Add.DynamicInvoke(<span class="visualBasic__number">1.0</span>,&nbsp;<span class="visualBasic__number">2.0</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.NumberCheckingLoop.DynamicInvoke(<span class="visualBasic__number">1</span>,&nbsp;<span class="visualBasic__number">10</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.AreEqual(<span class="visualBasic__number">5</span>,&nbsp;nums.Count)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TestMethod&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;DynamicallyTestForDynamicObject()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''Define&nbsp;a&nbsp;basic&nbsp;simple&nbsp;object</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;d&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;CustomizedDynamicObject()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.a&nbsp;=&nbsp;<span class="visualBasic__string">&quot;a&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.b&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''Define&nbsp;a&nbsp;nest&nbsp;object</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;nestObj&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;CustomizedDynamicObject()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nestObj.d&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nestObj.e&nbsp;=&nbsp;<span class="visualBasic__number">2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nestObj.array&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">Integer</span>()&nbsp;{<span class="visualBasic__number">1</span>,&nbsp;<span class="visualBasic__number">2</span>,&nbsp;<span class="visualBasic__number">3</span>,&nbsp;<span class="visualBasic__number">4</span>,&nbsp;<span class="visualBasic__number">5</span>,&nbsp;<span class="visualBasic__number">6</span>}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''Define&nbsp;an&nbsp;obj&nbsp;array</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dArrayObj&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;i&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;<span class="visualBasic__number">5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dObj&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;CustomizedDynamicObject()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dObj.f&nbsp;=&nbsp;i&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dObj.g&nbsp;=&nbsp;i.ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dArrayObj.Add(dObj)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nestObj.objArray&nbsp;=&nbsp;dArrayObj&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.c&nbsp;=&nbsp;nestObj&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''Do&nbsp;an&nbsp;implicit&nbsp;conversion</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;result&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;CTypeDynamic(d,&nbsp;<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">String</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.AreEqual(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>)(<span class="visualBasic__string">&quot;{a:'a',b:1,c:{d:1,e:2,array:[1,2,3,4,5,6],objArray:[{f:1,g:'1'},{f:2,g:'2'},{f:3,g:'3'},{f:4,g:'4'},{f:5,g:'5'}]}}&quot;</span>,&nbsp;result)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Namespace</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
