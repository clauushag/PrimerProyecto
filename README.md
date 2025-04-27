Somos alumnos de 1ºC del grado en Ingeniería Informática y esperamos que os guste nuestro simulador de aeropuerto 😎.

# Documento Detallado de Diseño (DDD)

**Identificación del Grupo:** Grupo 5  
**Fecha:** 18-04-2025

---

## Índice
1. Introducción
2. Descripción
   - Decisiones de diseño
   - Decisiones de desarrollo
   - Diagrama de clases
3. Problemas
4. Conclusiones

---

### Introducción
**Miembros del Grupo:**  
- Javier Mallo Martínez.  
- Jaime Ortega Fernández.
- Claudia Sánchez Aguilar.  

**Resumen:**  
En el documento vamos a ver la descripción detalla del diseño y del desarrollo y en la que podemos encontrar el diagrama de clases. Luego encontramos la sección de problemas en el que vamos a hablar de todos los problemas que hemos tenido a la hora de hacer el proyecto. Y por último hablaremos de las conclusiones que sacamos de este proyecto.

### Descripción
El proyecto que hemos realizado consiste en la simulación de un aeropuerto en el que podemos observar los movimientos de los diferentes aviones que existen en un aeropuerto.
1. **Decisiones de Diseño:**  
 Para la estructura utilizamos la arquitectura orientada objetos en la que creamos clases independientes que son la clase aeropuerto, la clase pista y la clase avión. Tuvimos que utilizar la herencia para crear los distintos tipos de aviones que son el AvionComercial, el AvionPrivado y el AvionCarga ya que estos derivan de la clase padre Avion.
La función del aeropuerto es gestionar las diferentes pistas del aeropuerto creadas en la clase Pista, a su vez cada pista solo puede gestionar un avión. Tuvimos que crear métodos para cargar los aviones desde archivos, añadir nuevos aviones y simular el paso del tiempo con la utilización de los ticks.
Cada clase tiene su función que son las siguientes:
-Clase aeropuerto: gestiona todas las pistas.
-Clase Pista: gestiona individualmente los aviones asignados a cada pista. 
-Clase Avion y sus subclases: se encarga de los aviones y sus características.

2. **Decisiones de Desarrollo:**  
Para el proyecto utilizamos el lenguaje C#. También se utilizó GitHub como sistema de control para hacer más fácil el trabajo en equipo y los cambios en el proyecto.
Los aspectos más destacados:
- Cargar los aviones desde los archivos.
- Se implementó el método "avanzarTicks" para simular el avance de los vuelos.
- Se incorporaron controles para evitar la asignación de múltiples aviones en una pista o que las distancias de los aviones fuesen negativas.

**Diagrama de Clases:**  

![alt text](image.png)

### Problemas
**Retos Enfrentados:**  
- **Problemas con el Programa:** Empezando por la clase avión no hemos tenido problemas recalcables, lo único que nunca habíamos trabajado con enumeraciones y tuvimos que buscar en internet como poder trabajar con ellas en cuanto a su construcción y su modo de empleo.
Sobre las clases hijas de avión no hemos tenido problemas.
En cuanto a la clase pista el método simular tick nos costó llegar a entender su funcionamiento, puesto que hubo dudas sobre si debíamos implementar un método independiente que restara un tick en cada paso de simulación o si debíamos restar un tick en cada método que necesitase de ello. También hemos tenido problemas con el array pista, que al principio no sabíamos cómo definir el array, no caímos en que el tipo era Pista hasta que decidimos que iba a ser un array de 2D formado por objetos de nuestra Pista.
La clase aeropuerto con diferencia fue la que más nos costó, empezando por su constructor, que no estábamos acostumbrados a no definir sus atributos y nos costó llegar a la conclusión de que el aeropuerto es una matriz de filas y columnas formada por pistas y que teníamos que ir recorriendo una a una para inicializarlas. 
El método cargar archivo se nos hizo un poco tedioso, pero al final cuando nos dimos cuenta de que simplemente debíamos fijarnos en como nos pasaban los archivos desde fuera del programa y tener cuidado con la conversión de los tipos de datos.
  
- **Problemas con el Repositorio:** En cuanto a Github, al no haber trabajado ningún proyecto desde un repositorio, al principio tuvimos problemas para descubrir cual era el modo de trabajo (hemos usado ramas independientes y mergeado al main). 
Tuvimos conflictos de nuestro código que al principio no sabíamos resolver, pero, al final pudimos compatibilizar nuestras versiones. 
Hubo un problema y es que uno de los participantes sacó las clases de la carpeta principal del proyecto y cambio la estructura en el repositorio. Pero al final conseguimos subsanar dicho error.

### Conclusiones
En general, en cuanto al código, en la explicación de lo que teníamos que realizar como proyecto parecía mucho más complejo de lo que al final ha sido. Al llevarlo al día y haciendo poquito a poco el código, entendiéndolo se nos ha hecho bastante ameno. La parte más problemática ha sido la de GitHub, ya que hemos tenido ciertos problemas con las ramas y con las carpetas con el código, lo que nos ha llevado a mover los archivos dentro del proyecto para que funcionara. 
Por otro lado, al haberlo dividido en ramas de cada uno de los creadores, nos ha llevado a una mejor organización y a evitar ciertos problemas si solo trabajáramos en una rama(main).
A pesar de ello, conseguimos terminar el proyecto haciendo que funcione de la forma indicada.
Con todo, creemos que, proyectos como este que de primera mano podíamos pensar que eran sencillos, en realidad son laboriosos y requieren de mucho trabajo, organización y constancia. Por tanto, la próxima vez valoraremos más el trabajo antes de suponer que puede ser algo “sencillo”.