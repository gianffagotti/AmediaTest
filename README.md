Test Técnico Amedia

Para utilizar el sitio web, deben actualizar el string de conexión en scr\AmediaTestCrud.Web -> appsettings.json

Con la tablas de tRol y tUsers ya se puede utilizar correctamente. Es necesario tener en cuenta que se considera al rol 'Admininstrador' con el ID = 1. También para poder iniciar sesión, el usuario debe estar activo, es decir sn_activo = 1.

_____________________________________

Stored Procedures:

Partiendo de que ya existen las tablas tUsers, tPelicula, tGenero y tGeneroPelicula, ejecutar script de migración en scripts -> script_test_migration.sql

1) Crear usuarios, cuyo documento no exista actualmente en la base de datos, en
caso de existir, debería devolver un mensaje de error, en caso contrario insertarlo
	-> Sp_tusers_a
2) Crear/Borrar/Modificar peliculas (Borrar es poner en 0 el stock de ventas y
alquileres)
	-> Sp_tpelicula_a | Sp_tpelicula_b | Sp_tpelicula_m
3) Crear géneros
	-> Sp_tgenero_a
4) Asignar géneros a películas, verificar que la película no tenga asignada el
género previamente.
	-> Sp_tgeneropelicula_a
5) Alquilar y Vender películas
	-> Sp_alquilar_pelicula | Sp_venta_pelicula
6) Obtener las películas en stock para alquiler
	-> Sp_tpeliculas_alquiler_en_stock
7) Obtener las películas en stock para vender
	-> Sp_tpeliculas_venta_en_stock
8) Alquilar película
	-> Sp_alquilar_pelicula
9) Vender pelicula
	-> Sp_venta_pelicula
10) Devolver película
	-> Sp_tpeliculas_devolver
11) Ver películas que no fueron devueltas y que usuarios la tienen
	-> Sp_tpeliculas_sin_devolver
12) Ver qué películas fueron alquiladas por usuario y cuánto pagó y que día
	-> Sp_tpeliculas_alquilada_por_usuario
13) Ver todas las películas, cuantas veces fueron alquiladas y cuanto se recaudo por ellas
	-> Sp_tpeliculas_alquiler_estadistica
