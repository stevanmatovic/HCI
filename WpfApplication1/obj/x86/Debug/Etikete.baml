   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	       WpfApplication1.Etikete   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   /localclr-namespace:WpfApplication1     5   	     � Title$  Etikete��5   	   $	��321��6   $	��523��6&   "   WpfApplication1.HelpProvider   HelpKey$ Forma��62   
������� J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Help��5      6<   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��tabelaEtiketa��5
   �   $	��232��6      
IsReadOnly . $
��Left=�6�   $	��Top=�6�   $	��377��6�   ��6    ��  �� Path$ ListaEtiketa� �� SelectedItem 6J   �� $ SelectedEtiketa� �� Mode$ OneWay=�6�   �� 5   
   -   5        $��izmeniEtiketuButton��5   e   $��Izmeni etiketu��6   $��23��6*   $
��Left=�66   $��
398,99,0,0q�6Q   $	��Top=�6�   $��91��6�   6�   �� 5   
   -   5        $��izbrisiEtiketuButton��5   g   $��Izbrisi etiketu��6   $��23��6+   $
��Left=�67   $��398,144,0,0q�6R   $	��Top=�6�   $��91��6�   6�   �� 5   
   -   5        $��okButton��5   Z   $��OK��6   $��23��6   $
��Left=�6*   $��219,247,0,0q�6E   $	��Top=�6j   $��75��6�    �� 	IsDefault . 6�   �� 5   
   -   5        $��cancelButton��5   a   $��	Odustanak��6   $��23��6%   $
��Left=�61   $��414,247,0,0q�6L   $	��Top=�6u   $��75��6�   6�   5      5      