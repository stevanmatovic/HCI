   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	        WpfApplication1.EtiqWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   )localclr-namespace:WpfApplication1  5   	     � Title$  
EtiqWindow��5   	   $	��335��6   "   WpfApplication1.HelpProvider   HelpKey$ Forma��6)   $	��480��6L   
������� J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Help��5      6<   .��5
      � $	��286��6   $	��454��6    � ColumnDefinitions 5   
   �� 5      $
��212* �6   �� 5      $
��194* �6    � RowDefinitions 5   
   �� 5      $	��48* �6   �� 5      $	��48* �6   �� 5      $
��110* �6   �� 5      $	��79* �6   .+�5   
   �� -   5        $��label1��5   y   $*��$Unesite jedinstvenu oznaku etikete: ��6   $��28��6?   $
��Left=�6K   $��	12,12,0,0q�6f   $	��Top=�6�   �� 5   
   -   5        $��label2��5   m   $��Izaberite boju etikete: ��6   $��28��63   $
��Left=�6?   $��	12,10,0,0q�6Z   $	��Top=�6{   $��1��6�   �� 5   
   -   5        $��label3��5   i   $��Unesite opis etikete:��6   $��28��60   $
��Left=�6<   $��12,8,0,0q�6W   $	��Top=�6w   $��2��6�   �� 5   
   -   5        $��opisEtikete��5   g   $��1��6   $��2��6"   $��84��6/   $
��Left=�6;   $��0,8,0,0q�6V   $	��Top=�6z   $	��204��6�   $ IzmenaOpisaEtikete��6�   .��6�   ��5      �� 5       �� NotifyOnValidationError .  �� UpdateSourceTrigger$ PropertyChanged=�5       �� Path$
 Opis�6A   	 �� ValidationRules	 5      &   WpfApplication1.StringValidation  5      5      .��5       5!      �� 5"   
   -   5        $��	idEtikete��5"   [   $��1��6   $��23��6"   $
��Left=�6.   $��0,14,0,0q�6I   $	��Top=�6l   $	��204��6�   $ UnosOznakeTipa��6�   .��6�   ��5#      �� 5$       . $ PropertyChanged=�5%      $ ID�6A   	 5&        5'      5)      .��5*      5+      �� 5,   
   -   5        $��sacuvajButton��5,   s   $��Sačuvaj��6   $��25��6#   $��Center=�6/   
 �� 	IsDefault
 . $��192,43,172,0q�6]   $	��Top=�6�   $��90��6�   $��3��6�   $��2��6�   6�   �� 5-   
   -   5        $��button3��5-   `   $��	Odustanak��6   $��23��6%   $
��Left=�61   $��
129,46,0,0q�6L   $	��Top=�6o   $��75��6�   $��3��6�   $��1��6�   #  Xceed.Wpf.Toolkit.ColorPicker  5.   
   -	   5        $��colorPicker��5.   U   $��1��6   $
��Left=�6(   $��0,10,0,0q�6C   $	��Top=�6h   $	��138��6�   $��1��6�   5/      50      