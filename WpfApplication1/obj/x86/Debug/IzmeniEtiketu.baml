   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	   #    WpfApplication1.IzmeniEtiketu   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   /localclr-namespace:WpfApplication1     5   	   X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  IzmeniEtiketu��5   	   $	��335��6   "   WpfApplication1.HelpProvider   HelpKey$ Forma��6,   $	��480��6O   
������� J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Help��5      6<   .��5
      � $	��293��6   $	��454��6    � ColumnDefinitions 5   
   �� 5      $
��212* �6   �� 5      $
��194* �6    � RowDefinitions 5   
   �� 5      $	��50* �6   �� 5      $	��50* �6   �� 5      $	��63* �6   �� 5      $
��131* �6   .+�5   
   �� -   5        $��label1��5   y   $*��$Unesite jedinstvenu oznaku etikete: ��6   $��28��6?   $
��Left=�6K   $��	12,12,0,0q�6f   $	��Top=�6�   �� 5   
   -   5        $��label2��5   l   $��Izaberite boju etikete: ��6   $��28��63   $
��Left=�6?   $��12,9,0,0q�6Z   $	��Top=�6z   $��1��6�   �� 5   
   -   5        $��label3��5   j   $��Unesite opis etikete:��6   $��28��60   $
��Left=�6<   $��	12,11,0,0q�6W   $	��Top=�6x   $��2��6�   �� 5   
   -   5        $��opisEtikete��5   h   $��1��6   $��2��6"   $��84��6/   $
��Left=�6;   $��1,13,0,0q�6V   $	��Top=�6{   $	��204��6�   $��2��6�   $ IzmenaOpisaEtikete��6�   .��6�   ��5      �� 5       �� NotifyOnValidationError .  �� UpdateSourceTrigger$ PropertyChanged=�5       �� Path$
 Opis�6A   	 �� ValidationRules	 5      &   WpfApplication1.StringValidation  5      5      .��5       5!      �� 5"   
   -   5        $��	idEtikete��5"   m   $��1��6   $��23��6"   $
��Left=�6.   
 �� 
IsReadOnly
 . $��0,17,0,0q�6[   $	��Top=�6~   $	��204��6�   .��6�   ��5#      �� 5$       . $ PropertyChanged=�5%      $ ID�6A   	 5&        5'      5)      .��5*      5+      �� 5,   
   -   5        $��sacuvajButton��5,   s   $��Sačuvaj��6   $��25��6#   $��Center=�6/    �� 	IsDefault . $��189,75,175,0q�6]   $	��Top=�6�   $��90��6�   $��2��6�   $��3��6�   6�   �� 5-   
   -   5        $��button3��5-   `   $��	Odustanak��6   $��23��6%   $
��Left=�61   $��
130,76,0,0q�6L   $	��Top=�6o   $��75��6�   $��1��6�   $��3��6�   #  Xceed.Wpf.Toolkit.ColorPicker  5.   
   -	   5        $��colorPicker��5.   U   $��1��6   $
��Left=�6(   $��0,15,0,0q�6C   $	��Top=�6h   $	��138��6�   $��1��6�   5/      50      