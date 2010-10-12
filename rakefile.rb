require 'rake'
require 'rake/clean'
require 'fileutils'

['build/tools/Rake','build'].each do|pattern|
  Dir.glob(File.join(File.dirname(__FILE__),pattern,"*.rb")).each do|item|
    puts item
    require item
  end
end

local_settings = LocalSettings.new
mspec_options = []
output_folders = [Project.startup_dir,Project.specs_dir]
solution_file = "solution#{local_settings[:use_vs2010] ? ".vs2010":""}.sln"

COMPILE_TARGET = 'debug'
CLEAN.include(File.join(Project.startup_dir,"*.*"))

task :default => ["specs:run"]

task :init  => :clean do
  cp_r "thirdparty/machine.specifications/.","artifacts"
  [Project.specs_dir,Project.report_folder].each{|folder| mkdir folder if ! File.exists?(folder)}
end


desc 'compiles the project'
task :compile do
  MSBuildRunner.compile :compile_target => COMPILE_TARGET, :solution_file => solution_file
end

namespace :specs do
  desc 'view the spec report'
  task :view do
    system "start #{Project.specs_dir}/#{Project.name}.specs.html"
  end

  desc 'run the specs for the project'
  task :run  => [:init,:compile] do
    sh "artifacts/mspec.exe", "--html", "#{Project.specs_dir}/#{Project.name}.specs.html", "-x", "example", *(mspec_options + Project.spec_assemblies)
  end
end

desc "open the solution"
task :sln do
  Thread.new do
    system "devenv #{solution_file}"
  end
end
