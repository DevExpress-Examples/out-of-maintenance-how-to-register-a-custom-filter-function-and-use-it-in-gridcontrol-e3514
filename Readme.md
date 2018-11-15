<!-- default file list -->
*Files to look at*:

* [IsDayOffFunction.cs](./CS/WindowsApplication3/IsDayOffFunction.cs) (VB: [IsDayOffFunction.vb](./VB/WindowsApplication3/IsDayOffFunction.vb))
* [Main.cs](./CS/WindowsApplication3/Main.cs) (VB: [Main.vb](./VB/WindowsApplication3/Main.vb))
* [Program.cs](./CS/WindowsApplication3/Program.cs) (VB: [Program.vb](./VB/WindowsApplication3/Program.vb))
<!-- default file list end -->
# How to register a custom filter function and use it in GridControl


<p>Starting from <strong>version 11.1</strong> it is possible to register a <strong>custom function globally</strong> .<br /><br /> To create this function, it is necessary to implement the <a href="http://documentation.devexpress.com/#CoreLibraries/clsDevExpressDataFilteringICustomFunctionOperatorBrowsabletopic"><u>ICustomFunctionOperatorBrowsable interface</u></a>. If you wish your custom function to be evaluated on the server side (for instance, when Server Mode is used) it is necessary to implement the <a href="http://documentation.devexpress.com/#CoreLibraries/clsDevExpressDataFilteringICustomFunctionOperatorFormattabletopic"><u>ICustomFunctionOperatorFormattable interface</u></a>. <br /> Finally, to register a custom function you should call the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressDataFilteringCriteriaOperator_RegisterCustomFunctiontopic"><u>CriteriaOperator.RegisterCustomFunction method</u></a> with your custom function instance at the application startup.</p>
<p>To show a custom function, for instance, within a column DateTime filter dropdown handle the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsBaseColumnView_ShowFilterPopupDatetopic"><u>GridView.ShowFilterPopupDate event</u></a>. In this event handler create a <strong>Fu</strong><strong>n</strong><strong>c</strong><strong>tionOperator </strong>instance and pass your custom function name to its constructor. Then, add this FunctionOperator to the e.List collection.</p>
<p>Also, it is possible to use a custom function within <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraFilterEditorFilterEditorControltopic"><u>FilterEditorControl</u></a>. To use the FilterEditorControl rather than a regular FilterControl in a grid, set the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsBaseColumnViewOptionsFilter_DefaultFilterEditorViewtopic"><u>GridView.OptionsFilter.DefaultFilterEditorView property</u></a> to any value except for Visual. So, you can enter your function in the FilterEditorControl by choosing the <strong>Text</strong> tab.</p>
<p>This example illustrates how to add a custom function that will determine whether or not a processed date is a day off and show it in a column DateTime filter dropdown.</p>

<br/>


