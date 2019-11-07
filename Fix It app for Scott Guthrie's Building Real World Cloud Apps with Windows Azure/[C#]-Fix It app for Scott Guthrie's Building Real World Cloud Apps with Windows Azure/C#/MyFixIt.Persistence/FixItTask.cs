//
// Copyright (C) Microsoft Corporation.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.ComponentModel.DataAnnotations;

namespace MyFixIt.Persistence
{
    public class FixItTask
    {
        public int FixItTaskId  { get; set; }
        [StringLength(80)]
        public string CreatedBy { get; set; }
        [Required]
        [StringLength(80)]
        public string Owner { get; set; }
        [Required]
        [StringLength(80)]
        public string Title { get; set; }
        [StringLength(1000)]
        public string Notes { get; set; }
        [StringLength(200)]
        public string PhotoUrl { get; set; }
        public bool IsDone      { get; set; }        
    }
}