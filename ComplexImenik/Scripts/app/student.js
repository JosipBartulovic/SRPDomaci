function student(name, lastName, sex, grade){
	this.Name = name;
	this.LastName = lastName;
	this.Sex = sex;
	this.Grade = grade;
	this.DateCreated = new Date(Math.random()*new Date());
	this.Age = Math.floor(Math.random() * 15) + 24  
	this.PrintText = name+" "+lastName;
	this.Details = this.PrintText+" "+grade+" "+this.Age+" "+sex;
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

function delete_student(name, lastName, $scope, localStorage){
	var students = localStorage.get('Students');
	students = _.remove(students, function(obj){
		if(obj.Name === name && obj.LastName === lastName){
			return false;
		};
		return true;
	})
	console.log(students);
	localStorage.set('Students',students);
}
