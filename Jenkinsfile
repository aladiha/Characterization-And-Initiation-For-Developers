pipeline {
    //Use the following docker image to run your dotnet app.
    agent { docker { image 'mcr.microsoft.com/dotnet/core/sdk:2.2-alpine' } }
    environment {HOME = '/tmp'} 
    stages {
        
    // Get some code from a GitHub repository
    stage('Git') {
      steps{
          git 'https://github.com/aladiha/nehool-project.git'
      }
   }
    stage('Dotnet Restore'){
        steps{
        sh "dotnet restore"
        }
    }
    
  stage('Build') {
   steps {
    Copy-Item "C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v14.0\WebApplications" "C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v15.0\WebApplications" -Recurse -Force
    sh "dotnet build"
   }
  }
  stage('Unit Tests') {
   steps {
    sh 'dotnet test'
   }
  }

  }
 }

