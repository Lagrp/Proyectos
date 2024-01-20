SELECT * FROM sgcmdb.usuarios;

SELECT usuarios.usu_id, usuarios.usu_personaId, usuarios.usu_perfilId, usuarios.usu_foto, 
concat(personas.per_nombre1,' ', personas.per_apellido1)nombreCorto 
FROM usuarios
JOIN personas ON usuarios.usu_personaId= personas.per_id
WHERE usu_id=2

