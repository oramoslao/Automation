Feature: Es una prueba para ver la edicion de wikipedia	

@mytag
Scenario: Edicion en Wikipedia
	Given Estoy en la pagina de Wikipedia de Produbanco
	And Hago click en editar
	Then El titulo de la pagina de edicion deberia incluir a la palabra "«Produbanco»"
