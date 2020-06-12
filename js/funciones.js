var funciones = {}, modulo;
(function(modulo) {
	(function(modulo) {
		var api = {
			test: function test() {
				alert("Hola mundo");
			}
		};
		$.extend(modulo, api);
	}((typeof moldulo === 'undefined' ) ? window : modulo));
}(funciones));