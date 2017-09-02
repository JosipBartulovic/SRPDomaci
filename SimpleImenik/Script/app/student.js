function student(name, lastName, sex){
	this.Name = name;
	this.LastName = lastName;
	this.Sex = sex;
	this.DateCreated = new Date(Math.random()*new Date());
	this.Age = Math.floor(Math.random() * 15) + 24  
	this.PrintText = name+" "+lastName+" "+sex;
}

function add_student_to_local_storage(localStorage, student){
	var students = localStorage.get('Students');
	students.push(student);
	localStorage.set('Students',students);
}

function get_all_students($scope, localStorage){
	var students = localStorage.get('Students');
	var male = _.filter(students, function(obj){
		return obj.Sex == 'M';
	}).reverse();
	male = _.sortBy(male,function(obj){ return obj.Age });

	var female = _.filter(students, function(obj){
		return obj.Sex == 'F';
	});
	female = _.sortBy(female, function(obj){ return obj.Age}).reverse();
	$scope.students = male.concat(female);
	return students;
}
