import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent {
  title = 'CLASS SORCE';

  // Declare a variável todos e inicialize com valores
  public todos = [
    { title: 'Tarefa 1' },
    { title: 'Tarefa 2' },
    { title: 'Tarefa 3' }
  ];
}


