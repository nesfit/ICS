@snap[north span-100]
# Windows Presentation Foundation
@snapend

@snap[midpoint span-100]
## Component Creating, Application Styling, Binding
@snapend

@snap[south-east span-30]
[ Jan Pluskal <ipluskal@fit.vutbr.cz> ]
@snapend

---
## What is Windows Presentation Foundation (WPF)
* "New" graphical system for Windows
* Enables creation of "Rich-media" application
* Clear separation of roles
  * *UI* (XAML) 
  * *Business logic* (C#, VB.NET)
* Based on technologies like *HTML, CSS, Flash*
* Hardware acceleration

@snap[east]
@img[span-60](/Lectures/Lecture_08/Assets/img/WPFlogo.jpg)
@snapend

+++
### Vector Graphics
* All applications writen with WPF are **Direct3D enabled**
 * **Vector based** engine ensures performance
 * *Rendering* is accelerated by *graphics card*
 * Benefits
   * Low CPU utilization -> low power consumption
   * Quality "rich-media UI"
 * *Vector graphics* enables *zooming, resolution changes, rotations* etc. without any quality loss
 * WPF implements
   * *Float point system* of logical pixels
   * *32-bit ARGB* color spectrum

+++
### Vector vs. Raster Graphics

![](/Lectures/Lecture_08/Assets/img/vector_vs_raster.jpg)

+++
### Rendering
* Works on the lowest layer with **shapes** not **pixels** 
* *Shapes* are represented by *vectors* and can be *easily manipulated*
* Developer defines a shape and lets WPF render it in the most optimal way
* WPF contains multiple predefined shapes
  * E.g., `Line, Rectangle, Ellipse, Path` etc...
* *Shapes* are used inside *panels* and multiplicity of other WPF component contents

+++
### Text Model
* Supports a wide range of *typographic* and *text rendering* functions
* *International fonts* and *composite fonts*
* WPF rendering engines use *ClearType* technologies
  * Fonts are *pre-rendered* and *stored in video memory*

+++
### Animations
* Supports timed animation
  * **Timers** are *initialized and managed by WPF*
  * Changes are coordinated by **Storyboard**
* Animations can be initialized
  * By *external events*
  * On *user inputs*
* Animations are *defined by XAML* declarations

+++
### Audio & Video
* Supports incorporation of *audio* and *video* into UI
* *Audio support* utilizes a thin layer based on *Win32* and *WMP* functions
* *Video support* uses native formats *WMV, MPEG* and subset of *AVI*
* Interaction between *video* and *animations*
  * Combination of *video* and *animations* creates dynamic content
  * *Animations* can be synchronized with media

---
## XAML
* **XAML** - e**X**tensible **A**pplication **M**arkup **L**anguage
* UI Declaration is based on **XAML**
* **Declarative language**
* Declares *behavior* and *interaction* of UI componets
* Form of *serialization of object hierarchy*
* *.NET namespaces* are represented by *XML namespaces*
* Typically closely connected with *Code-behind* class

@snap[east]
![](/Lectures/Lecture_08/Assets/img/XAMLlogo.png)
@snapend

+++
### XAML - Basics
* **XAML** is based on **XML**
* *Declaration* and *initiliazation* of *.NET objects*
* Used **to separate *UI* from *Code-behind***
  * *Backend* from *frontend*
* Contains element hierarchy representing visual objects
* These objects are called *user interface elements* or *UI elements*

+++
#### Hello WPF - Sample
![](/Lectures/Lecture_08/Assets/img/HelloWPF.png)

+++?code=/Lectures/Lecture_08/Assets/sln/HelloWpf/MainWindow.xaml&lang=XML&title=Hello WPF XAML
@[1,13]
@[2]
@[3-7]
@[5,6,8]
@[9]
@[10,12]
@[11]
[Code sample](/Lectures/Lecture_08/Assets/sln/HelloWpf/MainWindow.xaml)

+++?code=/Lectures/Lecture_08/Assets/sln/HelloWpf/MainWindow.xaml.cs&lang=C#&title=Hello WPF XAML Code Behind
@[8-14]
@[8]
@[10-13]
@[12]
@[8-14]
[Code sample](/Lectures/Lecture_08/Assets/sln/HelloWpf/MainWindow.xaml.cs)

+++
### Hello WPF - Explanation
* Declarations
  * *Window/UserControl/…* - inheritance
  * `x:Class` - class containing *Code-behind*
  * `xmlns:x` - mandatory namespace for XAML
  * `xmlns:d` - optional *design time* functionality
  * `mc:Ignorable` - ignoration of namespaces in *runtime*
  * `xmlns` - namespace with build-in components in WPF
* *Root element* `Windows` declares a partial class
* `Width, Height, Title` are *properties*
* *Element* `Button` declares item button

+++
### Elements & Attributes - Object Properties 
* `System.Windows.UIElement` (*UI Element*) have common subset of *properties* and *functions*
  * E.g., `Width, Height, Cursor, Tag` properties
* Declaration of XML *element* in XAML
  * Same effect as calling *parameterless constructor*
* Setting of *Attribute* on the element 
  * Same as *assigment to a property* of the same name.  
* **Attribute** – simple property
* **Element** – *UI Element*, complex property, class initialization

+++
### Property Elements
* Not all *properties* has to contain only a `string` 
* **Properties can contain instances of other objects**
* XAML defines syntactical notation for *complex property* definition called **property elements**
* Form *TypeName.PropertyName* contained inside *TypeName* element

```XML
<Grid>
   <Grid.ColumnDefinitions>
      <ColumnDefinition Width="1*"/>
      <ColumnDefinition Width="2*"/>
   </Grid.ColumnDefinitions>
</Grid>
```

---
## Class Hierarchy
* `System.Object`
* `System.Windows.DependencyObject`
  * Support dependency properties
* `System.Windows.UIElement`
  * Rendering methods
* `System.Windows.FrameworkElement`
  * Support for data-binding, styles, etc...
* `System.Windows.Controls.Control`
  * Base class for definitions of *UI Elements*

```
System.Object
  System.Windows.Threading.DispatcherObject
    System.Windows.DependencyObject
      System.Windows.Media.Visual
        System.Windows.UIElement
          System.Windows.FrameworkElement
            System.Windows.Controls.Control
```

---
## Controls
* Panels
* Content Controls
* ⋮
* [List of all controls](https://docs.microsoft.com/en-us/dotnet/framework/wpf/controls/control-library)

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
## Panels
* Are **the only components** that **can have multiple elements declared in content**
* Used to create a **layout** 
* Common practice in WPF
  * To use vector graphics
  * UI adapts to available space - **Flexible layout**

```
System.Object
  System.Windows.Threading.DispatcherObject
    System.Windows.DependencyObject
      System.Windows.Media.Visual
        System.Windows.UIElement
          System.Windows.FrameworkElement
            System.Windows.Controls.Panel
```

+++
### Canvas
* `Canvas`
* Position the content according to the **absolute x- and y-coordinates**
* Properties like `Canvas.Top, Canvas.Left, Canvas.Top, Canvas.Bottom`

![](/Lectures/Lecture_08/Assets/img/canvas.png)

+++
### Grid
* `Grid`
* Combination of: 
  * Absolute positioning
  * **Tabular data control**
* Properties like `Grid.Row, Grid.Column, Grid.RowSpan, Grid.ColumnSpan`

![](/Lectures/Lecture_08/Assets/img/Grid.png)

+++
### StackPanel and DockPanel
* `StackPanel`, `DockPanel`
* **Components are placed next to one-another**
* *Vertical* or *Horizontal* stacking
* Properties like `StackPanel.Orientation`, `DockPanel.Dock`
  
![](/Lectures/Lecture_08/Assets/img/StackVsDockPanel.png)
  * DockPanel - the last item is squeezed
  * StackPanel - the last item is trimmed

+++
### WrapPanel
* `WrapPanel`
* Components beside one-another and if there is no space, another row is created, or vice-versa
* *Concentration game (Pexeso)* like a design
* Properties `WrapPanel.Orientation`

![](/Lectures/Lecture_08/Assets/img/wrappanel.png)

+++
### Content Controls
* **Only one descendant**
* `Border` 
  * Border and background around some content
* `Button`
* `Label`
* `CheckBox, RadioButton`
* `ScrollViewer`
  * In case that content is longer or wider than space defined in the parent
  * Creates *scrolling bar*
* and others...

```
System.Object
  System.Windows.Threading.DispatcherObject
    System.Windows.DependencyObject
      System.Windows.Media.Visual
        System.Windows.UIElement
          System.Windows.FrameworkElement
            System.Windows.Controls.Control
              System.Windows.Controls.ContentControl
```

+++
### Positioning Properties
* `Width, MinWidth, MaxWidth`
* `HorizontalAlignment, VerticalAlignment`
  * Alignment related to parent element
* `HorizontalContentAlignment, VerticalContentAlignment`
  * Alignment of inner content
* `Margin, Padding`
  * Outer and inner borders

```
System.Object
  System.Windows.Threading.DispatcherObject
    System.Windows.DependencyObject
      System.Windows.Media.Visual
        System.Windows.UIElement
          System.Windows.FrameworkElement
```

+++
### Text Formating
* Element `TextBlock`
  * Property `TextWrapping`
  * Inner elements:
    * Element `Run`
      * Attributes `FontWeight, FontSize, Foreground…`
    * `LineBreak, Span, Hyperlink, Bold, Italic, Underline`

```XML
<TextBlock>
Sample text with <Bold>bold</Bold>, <Italic>italic</Italic> 
and <Underline>underlined</Underline> words.
Username: <Run FontWeight="Bold" Text="{Binding UserName}"/>
</TextBlock>
```

+++
### Other Interesting Components
* `Calendar`

![](/Lectures/Lecture_08/Assets/img/calendar.gif)

* `DatePicker`

![](/Lectures/Lecture_08/Assets/img/datepicker.jpeg)

+++

* `Image` 

* `ProgressBar`

![](/Lectures/Lecture_08/Assets/img/progressbar_simple.png)

* `TextBox`

![](/Lectures/Lecture_08/Assets/img/textbox.jpeg)

and others...

---
### DataContext
* Property of `FrameworkElement`
* References parent's `DataContext` if not set on an element.
* Perfect for *data-binding*
* Type `object`, thus can be set to anything

![](/Lectures/Lecture_08/Assets/img/DataContext.png)

+++
### Binding Markup

![](/Lectures/Lecture_08/Assets/img/BindingMarkup.png)

+++
### DataContex Sample
![](/Lectures/Lecture_08/Assets/img/DataContext_example.png)


+++
### Data-binding types
* Against current `DataContext`
  * `{Binding}`
    * Actual DataContext
  * `{Binding Name}`
    * Binds property `Name` on current `DataContext`
  * `{Binding Name.Length}`
    * Binds property `Name.Length` on current `DataContext`
* Against *named element*
  * property `x:Name`
  * `{Binding Path=Text, ElementName=TextBox1}`
    * Property `Text` on object `TextBox1`

+++
### Data-binding direction
* Defined by property `Mode`
  * `OneTime`
    * Only once when a component is initialized
  * `OneWay`
    * Only in one direction, from *source* to *target*
  * `TwoWay`
    * In both directions from *source* to *target* and from *target* to *source*
  * `OneWayToSource`
    * Only in one direction, from *target* to *source*
  * `Default`
    * Default value, usually:
      * User defined has `TwoWay`
      * Other has `OneWay`
* *Source* 
  * Property that we bind to
* *Target*
  * Component that defines `{Binding}`

+++
### Data-binding how it works?
* `OneWay` and `TwoWay` 
  * React to changes in the source
  * *Source* needs to notify that *something* has changes
    * `class` containing the *source* need to implement `INotifyPropertyChanged`
    * When *something* changes, `PropertyChanged` event needs to `Invoke()`

+++?code=/Lectures/Lecture_08/Assets/sln/Sample.App/Views/MainView.xaml&lang=XML&title=Binding Sample 1/3
@[7-8]
@[28-29]
@[41-42]
[Code sample](/Lectures/Lecture_08/Assets/sln/Sample.App/Views/MainView.xaml)

+++?code=/Lectures/Lecture_08/Assets/sln/Sample.App/ViewModels/Base/ViewModelBase.cs&lang=C#&title=Binding Sample 2/3
@[6-14]
@[8]
@[10-11, 13]
@[12]
@[6-14]
[Code sample](/Lectures/Lecture_08/Assets/sln/Sample.App/ViewModels/Base/ViewModelBase.cs)

+++?code=/Lectures/Lecture_08/Assets/sln/Sample.App/ViewModels/MainViewModel.cs&lang=C#&title=Binding Sample 2/3
@[7-8]
@[9-10]
@[12-13, 19-21]
@[23-31]
@[25]
@[26-27, 30]
@[28]
@[29]
@[23-31]
@[33-41]
[Code sample](/Lectures/Lecture_08/Assets/sln/Sample.App/ViewModels/MainViewModel.cs)

+++
### Binding to Collections
* *View-Model* declares a collection typed property, i.e., type implements `IEnumerable`
  * WPF sees items as a representation of collection's inner elements typed as `System.Object`
  * *Source* (collection) needs to notify that collection has changed, if you need to update the collection from *View-Model* side.
    * The collection needs to implement `INotifyCollectionChanged`
    * E.g., `ObservableCollection<T>`

```C#
public class MainViewModel {
   public ObservableCollection<MenuItem> MenuItems { get; } 
                     = new ObservableCollection<MenuItem>();
}

public class MenuItem {
  public string Title {get; set;}
  public string SubTitle {get; set;}
}
```

+++
### ItemsControls - Collection Visualization
* `ComboBox`
* `ListBox`
* `TabControl`
* `TreeView`
* ⋮
* `System.Windows.Controls.Control`
* `System.Windows.Controls.ItemsControl`

+++
### ItemsControl - Collection Visualization
* Property `Items`
  * General objects, rendered inside ItemControl
* Property `ItemsSource`
  * Uses `IEnumerable` as a source of rendered items
* Template `ItemTemplate`
  * Defines *look* and *content* of items
    * *DataContext* is set to the *current item*

```XML
<ListBox ItemsSource="{Binding MenuItems}">
   <ListBox.ItemTemplate>  
      <DataTemplate>
         <StackPanel>
            <TextBlock Text="{Binding Title}" />
            <TextBlock Text="{Binding SubTitle}" />
         </StackPanel>
      </DataTemplate> 
   </ListBox.ItemTemplate>
</ListBox>
```

+++
### ItemsControl - Collection Change
*  How to re-render collection?
*  Property `ItemsSource`
  * Assignment of a different object to the bound property
    * Content is cleared, now data is generated
  * Change of an item in the `ItemsSource` collection
    * Only with objects implementing interface `INotifyPropertyChanged`
  * Adding or Removing items in the collection
    * The collection must implement interface `INotifyCollectionChanged`

+++
### ItemsControl - ListBox
* Property `SelectedItem`
  * Object that is *bindable*
* Property `SelectedValuePath`
  * Defines path to a property that is bound by `SelectedValue`
  * E.g., `Object.Property1.Property2`
* Property `SelectedValue`
  * Value of property defined by `SelectedValuePath`

```XML
<ListBox 
    ItemsSource="{Binding MenuItems}" 
    SelectedItem="{Binding SelectedItem}" 
    SelectedValue="{Binding SelectedTitle}" 
    SelectedValuePath SelectedValuePath="@Title" 
/>
```

+++
### INotifyCollectionChanged
* Implemented by `ObservableCollection<T>`
  * Implements interface `INotifyCollectionChanged`
* User defined collection 
  * To implement interface `INotifyCollectionChanged`  
* Existing collections
  * To create a wrapper implementing `INotifyCollectionChanged`

+++?code=/Lectures/Lecture_08/Assets/sln/CollectionBinding/MainViewModel.cs&lang=C#&title=Binding Collection Sample 1/3
@[5-22]
@[7-19]
@[9-18]
@[21]
@[5-22]
[Code sample](/Lectures/Lecture_08/Assets/sln/CollectionBinding/MainViewModel.cs)

+++?code=/Lectures/Lecture_08/Assets/sln/CollectionBinding/MainWindow.xaml&lang=C#&title=Binding Collection Sample 2/3
@[9]
[Code sample](/Lectures/Lecture_08/Assets/sln/CollectionBinding/MainWindow.xaml)

+++
#### Binding Collection Sample 3/3

![](/Lectures/Lecture_08/Assets/img/CollectionBinding.png)

---
## Commands
* `Command` is an abstract and *loosely-coupled* version of `event`
* E.g., *Copy, Cut, Paste, Save, etc...*
* Reduces the necessary code amount
* Enables UI changes without a need to change *back-end* logic
* Commands have *action, source, target, and binding*

+++
### Command Class
* Implements interface `ICommand`
  * `public interface ICommand`
* Methods
  * `Execute(Object)`
    * Defines the method to be called when the command is executed
  * `CanExecute(Object)`
    * Defines the method that checks if the command can be executed 
* Event
  * `CanExecuteChanged`
    * Event that is called when condition used in `CanExecute(Object)` changes
    * `CanExecute(Object)` is reevaluated, and if changed, the command can be executed

+++
### Command Parameter
* Specify a command parameter using the `CommandParameter` property
* **Data** in this property **will be passed to the code** that runs when the command executes

```XML
<TextBox x:name="TextBox" Text="Hello!">

<Button Content="Send" Command="{Binding MyCommand}"
     CommandParameter="{Binding ElementName=TextBox, Path=Text}" />
```
@[1]
@[3-4]

```C#
public class ViewModel {
    public MyCommand MyCommand {get;} = new MyCommand();
}

public class MyCommand : ICommand {
    public void Execute(object parameter)
    {
        var textFromTextBox = parameter as string;
        ///....
    }

    public bool CanExecute(object parameter) => true;
    public event EventHandler CanExecuteChanged {get;}
}
```
@[5-7]
@[9-18]
@[10-14]
@[16]
@[17]
@[1-18]

+++?code=/Lectures/Lecture_08/Assets/sln/Sample.App/Views/MainView.xaml&lang=XML&title=Command Class Sample 1/4
@[45-48]
@[49-51]
[Code sample](/Lectures/Lecture_08/Assets/sln/Sample.App/Views/MainView.xaml)

+++?code=/Lectures/Lecture_08/Assets/sln/Sample.App/ViewModels/MainViewModel.cs&lang=C#&title=Command Class Sample 2/4
@[7-8]
@[12-13, 16-17, 21]
@[45-46]
[Code sample](/Lectures/Lecture_08/Assets/sln/Sample.App/ViewModels/MainViewModel.cs)

+++?code=/Lectures/Lecture_08/Assets/sln/Sample.App/Commands/WriteRightWithoutCanExecuteCommand.cs&lang=C#&title=Command Class Sample 3/4
@[7-8]
@[9]
@[11-14]
@[16-19]
@[21-24]
@[23]
@[26-30]
[Code sample](/Lectures/Lecture_08/Assets/sln/Sample.App/Commands/WriteRightWithoutCanExecuteCommand.cs)

+++?code=/Lectures/Lecture_08/Assets/sln/Sample.App/Commands/WriteRightWithCanExecuteCommand.cs&lang=C#&title=Command Class Sample 4/4
@[7-8]
@[16-19]
@[18]
@[16-19]
[Code sample](/Lectures/Lecture_08/Assets/sln/Sample.App/Commands/WriteRightWithCanExecuteCommand.cs)

+++
### Commands Benefits
* Wide range of *predefined commands*
* Provide **automated support for user input actions**
* Most of the components have **built-in support** for them
  * E.g. `button` has property `Command`
* *Clean Code* without *Code-behind*
* **Command design pattern**
  * Launches *action*
  * *Checks* if the action is permitted to launch

+++
### Commands - RelayCommand
* RelayCommand – [MVVM - Commands, RelayCommands and EventToCommand](https://msdn.microsoft.com/en-us/magazine/dn237302.aspx?f=255&MSPPError=-2147217396), Telerik

* MyViewModel.cs:

```C#
private RelayCommand myCommand;

public RelayCommand MyCommand => myCommand ?? 
   (myCommand = new RelayCommand(Execute,CanExecute);

private void Execute() {
      //...
}

private bool CanExecute() => true;
```

+++?code=/Lectures/Lecture_08/Assets/sln/Sample.App/Commands/RelayCommand.cs&lang=C#&title=Relay Command Sample 1/3
@[6-7]
@[8-9]
@[11-15]
@[17]
@[18-20]
@[22-26]
@[27-30]
@[32-36]
[Code sample](/Lectures/Lecture_08/Assets/sln/Sample.App/Commands/RelayCommand.cs)

+++?code=/Lectures/Lecture_08/Assets/sln/Sample.App/Views/MainView.xaml&lang=XML&title=Relay Command Sample 2/3
@[32-35]
@[36-38]
[Code sample](/Lectures/Lecture_08/Assets/sln/Sample.App/Views/MainView.xaml)

+++?code=/Lectures/Lecture_08/Assets/sln/Sample.App/ViewModels/MainViewModel.cs&lang=C#&title=Relay Command Sample 3/3
@[7-8]
@[12-15, 21]
@[43-44]
@[48-51]
@[53-56]
[Code sample](/Lectures/Lecture_08/Assets/sln/Sample.App/ViewModels/MainViewModel.cs)

---
## Value Conversion
* `IValueConverter`
* **Use a value of one type and then present it differently**
  * Used with data bindings
* E.g. *NullToVisibility*

+++?code=/Lectures/Lecture_08/Assets/sln/Sample.App/Views/MainView.xaml&lang=XML&title=Value Conversion Sample 1/2
@[32-35]
@[35]
@[45-48]
@[48]
[Code sample](/Lectures/Lecture_08/Assets/sln/Sample.App/Views/MainView.xaml)

+++?code=/Lectures/Lecture_08/Assets/sln/Sample.App/Converters/NullOrEmptyToIsEnabledConverter.cs&lang=C#&title=Value Conversion Sample 2/2
@[7-18]
@[9-12]
@[14-17]
@[7-18]
[Code sample](/Lectures/Lecture_08/Assets/sln/Sample.App/Converters/NullOrEmptyToIsEnabledConverter.cs)

---
## Views Opening
* Open **view inside another view**
```XML
<Window ...
    xmlns:views="clr-namespace:ViewsNamespace"
    ... >
    <views:AnotherView />
</Window>
```

* Open **view in new window**
  * Creating a new window is a job for the *ViewModel*
    * It is not part of ViewModel responsibilities to know, what View should be created
    * See [Demonstration project](/Lectures/Lecture_08/Assets/sln/OpeningWindow)
  * Recommends using MVVM framework
    * Solves problems with wrapping all this up

---
### Styles
* **Style** is a *set of properties* applied to the *content*
  * Defines *changes in rendering*
  * Concept is the same as with *CSS*
  * E.g., change *button's text's font*
* Used for **visual state standardization** to set the same set of properties for particular items
* WPF styles contain specific properties for UI creation
  * E.g., *begin a set of visual effects* as a *reaction to a user action*

+++
### Templates
* Enables **complex changes to UI** state of any WPF items
* **Available templates**
  * `ControlTemplate` – UI style sharing across multiple controls 
  * `ItemsPanelTemplate` – panel look, 
    * E.g. `ListBox`
  * `DataTemplate` – item look inside a panel
  * `HierarchicalDataTemplate` - object look inside panels with hierarchical structure
    * E.g., `TreeView`

+++
### Custom Control Creation
* *Class* which offers its own functionality
  * Style and template defined in *generic.xaml**
* `System.Windows.Controls.Primitives` Namespace
  * Contains **base classes and controls**
  * Intended to be used as part of other more complex controls

![](/Lectures/Lecture_08/Assets/img/CustomControl.png)

+++?code=/Lectures/Lecture_08/Assets/sln/CustomControl/MainWindow.xaml&lang=XML&title=Custom Control Sample
@[11-15]
[Code sample](/Lectures/Lecture_08/Assets/sln/CustomControl/MainWindow.xaml)

---
## Material Design In XAML Toolkit
* Material Design styles **for all major WPF Framework controls**
* Additional controls to support the theme
  * E.g. *Multi Action Buttons*, *Cards*, *Dialogs*, *Clock*
* **Easy configuration** of palette
* **Icon pack**
* PM> `Install-Package MaterialDesignThemes`
* [WPF Material Design Demo](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit/tree/master/MainDemo.Wpf)

@snap[north-east]
![](/Lectures/Lecture_08/Assets/img/MaterialDesign.png)
@snapend

+++
### Material Design Change

@snap[west]
![](/Lectures/Lecture_08/Assets/img/WithoutMaterial.png)
@snapend

@snap[east]
![](/Lectures/Lecture_08/Assets/img/WithMaterial.png)
@snapend

+++
### Material Design Quick Start 1/3
* Start new WPF project
* Install MaterialDesignThemes NuGet: `Install-Package MaterialDesignThemes`
* Edit *App.xaml* to following:

```XML
<Application . . . >
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

+++ 
### Material Design Quick Start 2/3
* Edit *MainWindow.xaml* to following:

```XML
<Window . . .
        xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"
        TextElement.Foreground="{DynamicResource MaterialDesignBody}"
        TextElement.FontWeight="Regular"
        TextElement.FontSize="13"
        TextOptions.TextFormattingMode="Ideal" 
        TextOptions.TextRenderingMode="Auto"        
        Background="{DynamicResource MaterialDesignPaper}"
        FontFamily="{DynamicResource MaterialDesignFont}">
    <Grid>
        <materialDesign:Card Padding="32" Margin="16">
            <TextBlock Style="{DynamicResource MaterialDesignTitleTextBlock}">My First Material Design App</TextBlock>
        </materialDesign:Card>
    </Grid>
</Window> 
```

+++
### Material Design Quick Start 3/3
* Run the app

![](/Lectures/Lecture_08/Assets/img/materialquickstart.png)

---
## Declarative UI - WPF Principle
* Designer, UI developer
  * Uses **Blend for Visual Studio** former **Expression Blend**
  * Edits only *XAML files*

![](/Lectures/Lecture_08/Assets/img/blend.png)

+++
* Developer
  * Uses **Visual Studio**
  * Works with *Code-behind*

![](/Lectures/Lecture_08/Assets/img/vs.jpg)

* Typically, the role of *Designer* and *Developer* overlaps

+++
### *Declarative* vs. *Imperative* UI
* **Supports both** *declarative* and *imperative* UI element instantiations
* **No difference** between both approaches
* Instantiation of UI element from *Code-behind* goes against WPF principle of *loose code coupling*
  * This approach was used in *Windows Forms*

MainWindows.xaml:

```XML
   <Button Content="Click ME!" />
```

MainWindow.xaml.cs:

```C#
   var button = new Button();
   button.Content = "Click ME!";
```

+++
### Declarative UI - WPF Principle
* What happens when *XAML is no used in WPF*?
  * Idea of **separation of concerns** is lost
  * *Designer* and *Developer* can not *coop* on the *same file*
    * Otherwise they create conflicts in source control
* What happens when *XAML is used in WPF*?
  * Object is created in declarative manner
  * *Parameter-less constructor* is called
  * All *magic* happens in `InitializeComponent()` method call

---
## Blend for Visual Studio
* Helps **design XAML-based Windows and Web applications**
* Same basic XAML design experience as Visual Studio
  * Adds visual designers for **advanced tasks such as animations and behaviors**
* [Blend More Informations](https://docs.microsoft.com/en-us/visualstudio/designers/creating-a-ui-by-using-blend-for-visual-studio?view=vs-2017)

@snap[north-east]
![](/Lectures/Lecture_08/Assets/img/BlendLogo.png)
@snapend

---
### Technologies Using WPF
* Silverlight
* Universal Windows Platform (UWP)
* Xamarin
* ⋮

@snap[south-east span+40]
![](/Lectures/Assets/img/MagnifyingGlass.png)
@snapend

+++
## Silverlight
  * Rich Internet Application (RIA) platform
* **Silverlight** is a cross-platform, cross-browser plug-in
  * Technology is based on WPF
  * Support "rich-media" functionality
  * E.g. *video, vector graphic, animations*
* **Silverlight** and WPF shares the same XAML presentation layer
  * Both technologies are very similar
    * **Silverlight is limited in some aspects**
    * Contains only a subset of WPF

@snap[east]
![](/Lectures/Lecture_08/Assets/img/SilverlightLogo.png)
@snapend

+++
### Silverlight - Deprecated
* End of overall support is scheduled to **5th of October 2021**  
  * *IE7-8* - support had been removed between 2014-2016 (depending on the OS)
  * *IE9-11* - support will last until late 2021
  * *Microsoft Edge* - no Silverlight plugin available
  * *Google Chrome* - no longer supported since September 2015
  * *Firefox* - no longer supported since March 2017
* Statistics from February 2018 show that **fewer than 0.1% sites used Silverlight**

+++
## Universal Windows Platform
* **Open source API** created by Microsoft
* First introduced in **Windows 10**
  * UWP apps do not run on earlier Windows versions
* Multiple ways how to use it
  * *XAML* UI and a *C#, VB, or C++* backend 
  * *DirectX* UI and a *C++* backend 
  * *JavaScript* and *HTML* 

+++
## Universal Windows Platform
![](/Lectures/Lecture_08/Assets/img/uwp.png)

+++
### UWP Device Family
![](/Lectures/Lecture_08/Assets/img/uwp_device_family.png)

+++
## Xamarin
* **Multi-platform development**
* Started for *mobile devices* to unify development for *all device families*
* Nowadays tries to *target all* mobiles, desktop, web...
![](/Lectures/Lecture_08/Assets/img/Xamarin_TraditionalvsForms.png)

+++
### Xamarin Sample

![](/Lectures/Lecture_08/Assets/img/Xamarin_allhanselman.png)

---
## WPF Demo
![](/Lectures/Lecture_08/Assets/img/demo.png)

---
## References:
[C# 7.0 in a Nutshell: The Definitive Reference](https://www.amazon.com/C-7-0-Nutshell-Definitive-Reference/dp/1491987650)  
[Microsoft .NET Documentation](https://docs.microsoft.com/en-us/dotnet/)  
[Vector-conversions.com](https://vector-conversions.com)  
[Material Design In XAML](http://materialdesigninxaml.net/)  
[Material Design In XAML - GitHub](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit)  
[Wikipedia](https://en.wikipedia.org/)  

+++
## Refences to used images:
[Fiverr - I Will Develop Wpf And Xaml Programs](https://www.fiverr.com/moustafashaban/develop-wpf-and-xaml-programs)  
[Microsoft .NET Documentation](https://docs.microsoft.com/en-us/dotnet/)  
[Material Design In XAML](http://materialdesigninxaml.net/)  
[David Pritchard website](http://davidpritchard.org/)  
[Vector-conversions.com](https://vector-conversions.com)  
[Wikipedia](https://en.wikipedia.org/)  

+++
## Credits
* Michal Orlíček - for slides preparation